using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerAction : MonoBehaviour
{
    public float interactionRange = 2.0f; // Distance within which the player can interact
    public LayerMask interactableLayer; // Layer for interactable objects

    public GameObject destroyedVersion; // Reference to the shattered version of the object
    public GameObject gif; // Reference to the gif object
    public GameObject trap; // Reference to the trap object

    public GameObject explode; // Explosion effect
    public GameObject powerGain; // Power-up effect

    public grenadeThrow grenadeThrowScript; // Reference to the grenadeThrow script

    bool life = true; // Player's life status
    public float lap; // Delay before reloading the scene
    public GameObject burn; // Burn effect when player dies

    public GameObject pressE; // UI for pressing "E" to interact
    public GameObject openUI; // UI element that shows when the game starts
    public GameObject plusBomb; // UI for bomb count increase

    void Start()
    {
        // Find the parent object of the main camera
        GameObject cameraParent = GameObject.Find("player"); // Replace with the actual parent object's name
        if (cameraParent != null)
        {
            // Find the main camera within the parent object
            Camera mainCamera = cameraParent.GetComponentInChildren<Camera>();
            if (mainCamera != null)
            {
                Debug.Log("Main camera found!");
                grenadeThrowScript = mainCamera.GetComponent<grenadeThrow>();
                if (grenadeThrowScript != null)
                {
                    Debug.Log("grenadeThrow script successfully found on the main camera.");
                }
                else
                {
                    Debug.LogError("grenadeThrow script not found on the main camera!");
                }
            }
            else
            {
                Debug.LogError("Main camera not found as a child of the parent object!");
            }
        }
        else
        {
            Debug.LogError("Parent object not found!");
        }

        // Display UI at the start
        GameObject open = Instantiate(openUI, transform.position, transform.rotation);
        Destroy(open, 5f);
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Perform a spherecast from the player's position
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, interactionRange, interactableLayer))
            {
                // Interact with the object
                InteractWithBox(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("No interactable object found within range.");
            }
        }

        // Perform a spherecast from the player's position to check for traps
        RaycastHit burned;
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out burned, interactionRange, interactableLayer))
        {
            // Interact with the fire trap
            InteractWithfireTtap(burned.collider.gameObject);
        }
    }

    void InteractWithBox(GameObject box)
    {
        Debug.Log("Interacted with: " + box.name);

        if (box.name == "gifbombbox")
        {
            Vector3 newPosition = box.transform.position;
            newPosition.y += 2f;

            GameObject gg = Instantiate(gif, newPosition, box.transform.rotation);
            Destroy(box);

            GameObject showBomb = Instantiate(plusBomb, transform.position, transform.rotation);
            Destroy(showBomb, 4f);

            Instantiate(destroyedVersion, box.transform.position, box.transform.rotation);
            Destroy(gg, 2f);

            GameObject power = Instantiate(powerGain, transform.position, transform.rotation);
            Destroy(power, 2f);

            IncreaseBombCount(1);
        }

        if (box.name == "trapbox")
        {
            Vector3 newPosition = box.transform.position;
            newPosition.y += 2f;

            GameObject dmt = Instantiate(trap, newPosition, box.transform.rotation);
            Destroy(box);

            Instantiate(destroyedVersion, box.transform.position, box.transform.rotation);
            Destroy(dmt, 0.5f);

            GameObject exp = Instantiate(explode, newPosition, box.transform.rotation);
            Destroy(exp, 2f);

            life = false;
            GameObject deadFire = Instantiate(burn, transform.position, transform.rotation);
            Destroy(deadFire, 3f);
        }

        if (!life)
        {
            Cursor.lockState = CursorLockMode.None;
            life = true;
            StartCoroutine(LoadSceneAfterDelay(lap));
        }
    }

    void InteractWithfireTtap(GameObject trap)
    {
        Debug.Log("Interacted with: " + trap.name);

        if (trap.name == "firePlate(Clone)")
        {
            Debug.Log("fire fire");
            life = false;
        }
        if (trap.name == "trapbox" || trap.name == "gifbombbox")
        {
            GameObject hitplate = Instantiate(pressE, transform.position, transform.rotation);
            Destroy(hitplate, 0.2f);
        }
        if (trap.name == "P1lost")
        {
            Debug.Log("paint detect");
        }

        if (!life)
        {
            Cursor.lockState = CursorLockMode.None;
            life = true;
            StartCoroutine(LoadSceneAfterDelay(lap));
        }
    }

    public void IncreaseBombCount(float amount)
    {
        if (grenadeThrowScript != null)
        {
            grenadeThrowScript.bombCount += amount;
            Debug.Log("Bomb count increased to: " + grenadeThrowScript.bombCount);
        }
        else
        {
            Debug.LogError("GrenadeThrow script not found!");
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Force garbage collection
        System.GC.Collect();
        Resources.UnloadUnusedAssets(); // Clean up unused assets

        // Ensure proper quality settings
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel(), true);

        // Load the new scene
        SceneManager.LoadScene(1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("trapflame"))
        {
            Debug.Log("Burnning.......... ");
            life = false;
        }

        if (!life)
        {
            Cursor.lockState = CursorLockMode.None;
            life = true;
            StartCoroutine(LoadSceneAfterDelay(lap));
        }
    }
}
