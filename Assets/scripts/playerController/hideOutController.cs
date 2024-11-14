using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideOutController : MonoBehaviour
{
    public bool playerHide = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        // Check if the collided object has the tag 
        if (other.gameObject.CompareTag("cover"))
        {
            Debug.Log("Player is in hideout area.");

            // Check if the "C" button is held down
            if (Input.GetKey(KeyCode.C))
            {
                playerHide = true;
                Debug.Log("Player is hiding.");
            }
            else
            {
                playerHide = false;
                Debug.Log("Player is not hiding.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the hideout area
        if (other.gameObject.CompareTag("cover"))
        {
            playerHide = false;
            Debug.Log("Player left the hideout area.");
        }
    }


}
