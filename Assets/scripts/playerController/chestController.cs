using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{

    public GameObject playerTorch;
    public GameObject chestTorch;

    private Animator animator;
    private int isOpen;

    public bool torchFound=false;

     
    void Start()
    {
        torchFound = false;
        playerTorch.SetActive(false);

        animator = GetComponent<Animator>();
        isOpen = Animator.StringToHash("isOpen");

 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        // Check if the collided object has the tag 
        if (other.gameObject.CompareTag("Player"))
        {
           // Debug.Log("torch.");

           if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool(isOpen, true);
                Destroy(chestTorch, 2f); // Fixed destroy delay
                playerTorch.SetActive(true);
                torchFound = true;


            }
        }
    }

}
