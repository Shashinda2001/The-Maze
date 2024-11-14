using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerOpen : MonoBehaviour
{
    
    private computerUIroute computerUIroute;
    private bool islockerOpen = false;

    private Animator animator;
    private int locker;
    void Start()
    {
        computerUIroute = FindAnyObjectByType<computerUIroute>();

        if (computerUIroute==null)
        {
            Debug.Log("script not found");
        }

        animator = GetComponent<Animator>();
        locker = Animator.StringToHash("wantOpen");
    }

    // Update is called once per frame
    void Update()
    {
        if (computerUIroute.locker)
        {
            openLocker();
            
        }
        else
        {
            closeLocker();
             
        }

    }

    private void openLocker()
    {
        if (!islockerOpen)
        {
            animator.SetBool(locker, true);
            islockerOpen = true;
        }
       
    }

    private void closeLocker()
    {
        if (islockerOpen)
        {
            animator.SetBool(locker, false);
            islockerOpen = false;
        }
           
    }
}
