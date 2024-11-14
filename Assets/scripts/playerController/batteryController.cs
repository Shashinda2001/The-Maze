using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryController : MonoBehaviour
{
    public float radius = 5f; // Set the radius
    public string[] tagsToCheck; // Array of tags you're interested in


    private Animator animator;
    private int isPick;

    public int betteryCount = 0;
    bool isDestroy = false;

    private capacitorController batCnt;
     void Start()
    {
        animator = GetComponent<Animator>();
        isPick = Animator.StringToHash("isInteract");

        batCnt = FindObjectOfType<capacitorController>();

        if (batCnt == null)
        {
            Debug.LogWarning("capacitorController not found in the scene.");
        }
        batCnt.batteryCount = 0;
    }

    void CheckTags()
    {
        // Define the center as the current position of the GameObject this script is attached to
        Vector3 center = transform.position;

        // Get all colliders within the radius
        Collider[] colliders = Physics.OverlapSphere(center, radius);

        // Iterate through the colliders and check their tags
        foreach (Collider collider in colliders)
        {
            string objectTag = collider.gameObject.tag;

            // Check if the object's tag is in the tagsToCheck array
            foreach (string tag in tagsToCheck)
            {
                if (objectTag == tag && !isDestroy)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        isDestroy = true;
                        animator.SetBool(isPick, true);
                        betteryCount++;
                        batCnt.batteryCount++;
                        Debug.Log(betteryCount);
                        Destroy(gameObject, 2f);
                        StartCoroutine(CheckIfDestroyed());
                    }
                   // Debug.Log("Found object with tag: " + objectTag);
                }
            }
        }
    }

    // For testing, you could call this in Update or with a button press
    void Update()
    {
        
            CheckTags();
        
    }
    IEnumerator CheckIfDestroyed()
    {
        yield return new WaitForSeconds(2f); // Wait for the destroy delay
        if (gameObject == null)
        {
             
           
            isDestroy = false;
           // Debug.Log(betteryCount);
        }
    }
}
