using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    private bool doorOpen = false;
    private Animator animator;
    private int door;
    void Start()
    {
        

        animator = GetComponent<Animator>();
        door = Animator.StringToHash("wantOpen");
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
            

            if (Input.GetKeyDown(KeyCode.E) && doorOpen)
            {
                animator.SetBool(door, false);

                StartCoroutine(changeDoorState(doorOpen));
            }


            if (Input.GetKeyDown(KeyCode.E) && !doorOpen)
            {

                animator.SetBool(door, true);
                StartCoroutine(changeDoorState(doorOpen));
            }

        }
    }

    private IEnumerator changeDoorState(bool state)
    {
        yield return new WaitForSeconds(1f);

        if (state)
            doorOpen = false;
        else
            doorOpen = true;
    }
            

}
