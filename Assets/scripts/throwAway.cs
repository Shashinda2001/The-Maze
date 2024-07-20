using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwAway : MonoBehaviour
{
    public GameObject throwPlate;
    
    bool throws =false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
        Debug.Log("got you");
        if (!throws)
        {
            Vector3 newPosition = transform.position;
            newPosition.y +=5f; // Adjust the value as needed
            Instantiate(throwPlate, newPosition, transform.rotation);
            throws = true;
        }
      
        // Increase the y-coordinate to move the position up
      

        // Instantiate the trap at the new position
       
    }
}
