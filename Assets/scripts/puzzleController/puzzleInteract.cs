using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public PuzzleManager1 PuzzleManager1;
    public PlayerMovement playerMovement;

    private capacitorController capacitor;
    void Start()
    {
        capacitor = FindObjectOfType<capacitorController>();

        if (capacitor == null)
        {
            Debug.LogWarning("capacitorController not found in the scene.");
        }
        PuzzleManager1 = FindObjectOfType<PuzzleManager1>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (PuzzleManager1 == null || playerMovement == null)
        {
            Debug.LogWarning("scripts not found in the scene.");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        // Check if the collided object has the tag "paint1p2"
        if (other.gameObject.CompareTag("Player"))
        {
            if (capacitor.capacitorState)
            {
                bool stopplayer = playerMovement.stopWalking;
                // Debug.Log("ready start");

                if (Input.GetKeyDown(KeyCode.E) && !PuzzleManager1.isreach)
                {
                    Debug.Log("start");
                    PuzzleManager1.isreach = true;
                    stopplayer = false;
                }

                if (Input.GetKeyDown(KeyCode.Q) && PuzzleManager1.isreach)
                {
                    PuzzleManager1.isreach = false;
                    Debug.Log("leave");
                    stopplayer = true;
                }
                playerMovement.stopWalking = stopplayer;
                //  Debug.Log("jjj");
            }
            else
            {
                Debug.Log("no electricity");
            }
         
        }
    }
}
