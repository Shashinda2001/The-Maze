using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmateController : MonoBehaviour
{
    public GameObject suite;
    public GameObject helmate;

   public bool suiteState = true;

    void Start()
    {
        suiteState = true;
        helmate.SetActive(false);
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
           // Debug.Log("suite ................");

            if (Input.GetKeyDown(KeyCode.E) && suiteState)
            {
                suiteState = false;
                helmate.SetActive(true);
                Destroy(suite, 1f);
                Destroy(gameObject, 1f);

               


            }
        }
    }
}
