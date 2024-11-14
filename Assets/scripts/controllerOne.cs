using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerOne : MonoBehaviour
{
    private GameObject lavaPlate;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isAtTargetPosition = false; // Flag to check if at the target position
    public float speed = 2.0f; // Speed of movement

    private capacitorController capacitor;

    // Start is called before the first frame update
    void Start()
    {

        capacitor = FindObjectOfType<capacitorController>();

        if (capacitor == null)
        {
            Debug.LogWarning("capacitorController not found in the scene.");
        }
        // Find the lava plate by its tag
        lavaPlate = GameObject.FindGameObjectWithTag("lava");

        // Set the initial and target positions
        initialPosition = new Vector3(62.3585281f, -43.0644913f, 103.45591f);
        targetPosition = new Vector3(62.3585281f, -77.0999985f, 103.45591f);
       // Vector3(62.3585281, -77.0999985, 103.45591)

        // Set the lavaPlate to its initial position at the start
        lavaPlate.transform.position = initialPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        // Only trigger when the object has the tag "controller1"
        if (other.gameObject.CompareTag("controller1"))
        {
          //  Debug.Log("controller1 triggered");

            // Check if the 'E' key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                bool checkState = capacitor.capacitorState;
                if (checkState)
                {
                    // Toggle between moving to the target position or back to the initial position
                    if (isAtTargetPosition)
                    {
                        StartCoroutine(MoveLavaPlate(initialPosition)); // Move back to the initial position
                    }
                    else
                    {
                        StartCoroutine(MoveLavaPlate(targetPosition)); // Move to the target position
                    }

                    // Toggle the state
                    isAtTargetPosition = !isAtTargetPosition;
               }
               
            }
        }
    }

    // Coroutine to move the lavaPlate between positions smoothly
    private IEnumerator MoveLavaPlate(Vector3 destination)
    {
        while (Vector3.Distance(lavaPlate.transform.position, destination) > 0.01f)
        {
            lavaPlate.transform.position = Vector3.MoveTowards(lavaPlate.transform.position, destination, speed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is exactly at the destination
        lavaPlate.transform.position = destination;
    }
}
