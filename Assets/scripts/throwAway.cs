using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwAway : MonoBehaviour
{
    public GameObject throwPlate;
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
       
        Debug.Log("got you");
        
        

            Debug.Log("drop");
            Vector3 newPosition = transform.position;
            newPosition.y +=5f; // Adjust the value as needed
            newPosition.z += 10f; // Adjust the value as needed
          GameObject deadFire= Instantiate(throwPlate, newPosition, transform.rotation);
            Destroy(gameObject);
            Destroy(deadFire, 3f);
         
           
        
      
        // Increase the y-coordinate to move the position up
      

        // Instantiate the trap at the new position
       
    }
}
