using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public float interactionRange = 2.0f; // Distance within which the player can interact
    public LayerMask interactableLayer; // Layer for interactable objects
     
    public GameObject destroyedVersion; // Reference to the shattered version of the object
    public GameObject gif; // Reference to the shattered version of the object
    public GameObject trap;

    public GameObject explode;
    public GameObject powerGain;
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
            // Spawn a shattered object
            Instantiate(destroyedVersion, box.transform.position, box.transform.rotation);
            Destroy(gg, 2f);
            // Remove the current object
          

            GameObject power = Instantiate(powerGain, transform.position,transform.rotation);
            Destroy(power, 2f);
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
            Destroy(dmt,0.5f);
            GameObject exp= Instantiate(explode, newPosition, box.transform.rotation);
            Destroy(exp,2f);

            // Remove the current object
           
        }


      

        // Perform any action you want here, such as opening the box, picking it up, etc.
    }
}