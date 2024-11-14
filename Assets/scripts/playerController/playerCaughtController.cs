using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCaughtController : MonoBehaviour
{
    private Animator animator;
    private int isPressC;

    void Start()
    {
        animator = GetComponent<Animator>();
        isPressC = Animator.StringToHash("pressC");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "C" button is held down
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool(isPressC, true);  // Set pressC to true
        }
        else
        {
            animator.SetBool(isPressC, false); // Set pressC to false when "C" is not held down
        }
    }

}
