using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elavatorOpen : MonoBehaviour
{
    private computerUIroute computerUIroute;
    private bool iselavator = false;

    private Animator animator;
    private int elavator;
    void Start()
    {
        computerUIroute = FindAnyObjectByType<computerUIroute>();

        if (computerUIroute == null)
        {
            Debug.Log("script not found");
        }

        animator = GetComponent<Animator>();
        elavator = Animator.StringToHash("wantOpen");
    }

    // Update is called once per frame
    void Update()
    {
        if (computerUIroute.elavator )
        {
            openDoor();
            
        }
        else
        {
            closeDoor();
            
        }

    }

    private void openDoor()
    {
        if (!iselavator)
        {
            animator.SetBool(elavator, true);
            iselavator = true;
        }
    }

    private void closeDoor()
    {
        if (iselavator)
        {
            animator.SetBool(elavator, false);
            iselavator = false;
        }

    }
}
