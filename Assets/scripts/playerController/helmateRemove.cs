using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmateRemove : MonoBehaviour
{
    

    private Animator animator;
    private int helmate;

    private bool isDown = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        helmate = Animator.StringToHash("needToWhere");

        


 

    }

    // Update is called once per frame
    void Update()
    {
       
        
            if (Input.GetKeyDown(KeyCode.H) && isDown){

            Debug.Log("hhhhhhhhhh");
                animator.SetBool(helmate, false);
            StartCoroutine(changeBool(isDown));
            }


            if (Input.GetKeyDown(KeyCode.H) && !isDown)
            {
            Debug.Log("hhhhhhhhhh");
            animator.SetBool(helmate, true);
            StartCoroutine(changeBool(isDown));
        }
       
    }

    private   IEnumerator changeBool(bool state)
    {

        yield return new WaitForSeconds(1f);
        if (state)
        {
            isDown = false;
        }
        else
        {
            isDown = true;
        }
    }
}
