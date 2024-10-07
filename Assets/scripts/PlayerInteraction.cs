using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2.0f; // Distance within which the player can interact
    public LayerMask interactableLayer; // Layer for interactable objects

    public GameObject destroyedVersion; // Reference to the shattered version of the object
    public GameObject gif; // Reference to the shattered version of the object
    public GameObject trap;

    public GameObject explode;
    public GameObject powerGain;

    public grenadeThrow grenadeThrowScript;

    //bool life = true;
    public float hart = 2f;
    public float lap;
    public GameObject burn;

    public GameObject pressE;

     
    public GameObject plusBomb;

    private bool isLosingHealth = false; // Flag to check if health is already decreasing

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

        // Perform a spherecast from the player's position
        RaycastHit burned;
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out burned, interactionRange, interactableLayer))
        {
            // Interact with the object
            InteractWithfireTtap(burned.collider.gameObject);
        }
    }

    void InteractWithBox(GameObject box)
    {
        // Example interaction logic (you can customize this)
        Debug.Log("Interacted with: " + box.name);

        if (box.name == "gifbombbox")
        {
            Vector3 newPosition = box.transform.position;
            // Increase the y-coordinate to move the position up
            newPosition.y += 2f; // Adjust the value as needed

            // Instantiate the trap at the new position
            GameObject gg = Instantiate(gif, newPosition, box.transform.rotation);
            Destroy(box);

            GameObject showBomb = Instantiate(plusBomb, transform.position, transform.rotation);
            Destroy(showBomb, 4f);
            // Spawn a shattered object
            Instantiate(destroyedVersion, box.transform.position, box.transform.rotation);
            Destroy(gg, 2f);
            // Remove the current object

            GameObject power = Instantiate(powerGain, transform.position, transform.rotation);
            Destroy(power, 2f);
            // Increase bomb count
            IncreaseBombCount(1);
        }

        if (box.name == "trapbox")
        {
            Vector3 newPosition = box.transform.position;
            // Increase the y-coordinate to move the position up
            newPosition.y += 2f; // Adjust the value as needed

            // Instantiate the trap at the new position
            GameObject dmt = Instantiate(trap, newPosition, box.transform.rotation);
            Destroy(box);
            // Spawn a shattered object
            Instantiate(destroyedVersion, box.transform.position, box.transform.rotation);
            Destroy(dmt, 0.5f);
            GameObject exp = Instantiate(explode, newPosition, box.transform.rotation);
            Destroy(exp, 2f);
            StartCoroutine(DecreaseHealthWithDelay(2f)); // Decrease health with a delay
            GameObject deadFire = Instantiate(burn, transform.position, transform.rotation);
            Destroy(deadFire, 3f);

            StartCoroutine(LoadSceneAfterDelay(lap));
        }

        if (hart <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
          //  hart = 2f;
            StartCoroutine(LoadSceneAfterDelay(lap));
        }
    }

    void InteractWithfireTtap(GameObject trap)
    {
        Debug.Log("Interacted with: " + trap.name);

        if (trap.name == "firePlate(Clone)")
        {
            Debug.Log("fire fire");
            StartCoroutine(DecreaseHealthWithDelay(2f)); // Decrease health with a delay
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

        if (hart <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
          //  hart = 2f;
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
        SceneManager.LoadScene(1);
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the collided object has the tag "trapflame"
        if (other.gameObject.CompareTag("trapflame"))
        {
            Debug.Log("Burning.......... ");
            StartCoroutine(DecreaseHealthWithDelay(2f)); // Decrease health with a delay
        }

        if (hart <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
           // hart = 2f;
            StartCoroutine(LoadSceneAfterDelay(lap));
        }
    }

    private IEnumerator DecreaseHealthWithDelay(float delay)
    {
        if (!isLosingHealth) // Check if health is already decreasing
        {
            isLosingHealth = true; // Set the flag to true to prevent rapid health loss
            hart--; // Decrease health
            yield return new WaitForSeconds(delay);

            Debug.Log("Health decreased. Current health: " + hart);
            isLosingHealth = false; // Reset the flag after health is decreased
        }
    }
}
