using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public float interactionRange = 2.0f; // Distance within which the player can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    public string interactableTag = "Destructible";
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

             //   if (hit.collider.CompareTag(interactableTag))
             //   {
             //       Destructible dest = hit.collider.GetComponent<Destructible>();
               //     if (dest != null)
               //     {
                        // Interact with the destructible object by calling the open method
               //         dest.opened();
               //     }
             //   }
                    
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
        // Perform any action you want here, such as opening the box, picking it up, etc.
    }
}