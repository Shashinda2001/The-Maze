using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f;
    bool hasExploded = false;
    public GameObject explodeEfect;
    public float radius=5f;
    public float force = 200f;
    float countdown;
    void Start()
    {
        countdown = delay;
    }


    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            hasExploded = true;
            Explode();
            
        }
       
    }

   void Explode()
    {
        //show fire effect
        GameObject effectInstance = Instantiate(explodeEfect, transform.position, transform.rotation);

        //Destroy fire object
        Destroy(effectInstance, 2f);


        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            { 
                //add force
                rb.AddExplosionForce(force, transform.position, radius);
            }

            //add damage
            destructible dest = nearbyObject.GetComponent<destructible>();
            if (dest != null)
            {
                dest.triggerdestroy();
            }
        }

        //kadena kali wisikaranna
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add force
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        //damage

        Destroy(gameObject);
         

        Debug.Log("boooom");
    }
}
