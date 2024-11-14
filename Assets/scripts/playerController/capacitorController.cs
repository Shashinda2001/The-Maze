using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capacitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public int batteryCount;
    public float radius = 5f;
    public bool capacitorState = false;

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject bat1;
    public GameObject bat2;
    public GameObject bat3;
    public GameObject mainWire;
    void Start()
    {
        l1.SetActive(false);
        l2.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(false);
        bat1.SetActive(false);
        bat2.SetActive(false);
        bat3.SetActive(false);
        mainWire.SetActive(false);
    }

    // Update is called once per frame
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
            
                if (objectTag =="Player")
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                    if (batteryCount == 1)
                    {
                        l1.SetActive(true);
                        bat1.SetActive(true);
                    }
                    else if(batteryCount == 2) {
                        l1.SetActive(true);
                        bat1.SetActive(true);
                        l2.SetActive(true);
                        bat2.SetActive(true);
                    }
                    else if (batteryCount == 3) {
                        l1.SetActive(true);
                        l2.SetActive(true);
                        l3.SetActive(true);
                        l4.SetActive(true);
                        bat1.SetActive(true);
                        bat2.SetActive(true);
                        bat3.SetActive(true);
                        capacitorState = true;
                        mainWire.SetActive(true);
                    }

                }
                    
                }
            
        }
    }

    // For testing, you could call this in Update or with a button press
    void Update()
    {
        

        CheckTags();

    }
}
