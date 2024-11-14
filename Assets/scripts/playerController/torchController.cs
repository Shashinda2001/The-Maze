using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchController : MonoBehaviour
{
    private Animator animator;
    private int Torch;

   public bool torchFound=false;
    private bool torchOn=false;
    

    private chestController chestController;
    public float timeGap=2f;



    void Start()
    {
        torchFound = false;
        animator = GetComponent<Animator>();
        Torch = Animator.StringToHash("isTorchOff");

        chestController = FindAnyObjectByType<chestController>();

        if (chestController == null)
        {
            Debug.LogError("script not found");
        }

        animator.SetBool(Torch, false);
        torchOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        torchFound = chestController.torchFound;
        if (torchFound)
        {
            if (Input.GetKeyDown(KeyCode.G) && !torchOn)
            {
                StartCoroutine(makeTorchOn());
               
               
            }

            if (Input.GetKeyDown(KeyCode.G) && torchOn)
            {
                StartCoroutine(makeTorchOff());
               
            }
        }
    }

    private IEnumerator makeTorchOn()
    {
        Debug.Log("torch on");
        animator.SetBool(Torch, false);
       
        yield return new WaitForSeconds(timeGap);
        torchOn = true;
    }

    private IEnumerator makeTorchOff()
    {
        animator.SetBool(Torch, true);
        Debug.Log("torch off");
       
        yield return new WaitForSeconds(timeGap);
        torchOn = false;
    }
}
