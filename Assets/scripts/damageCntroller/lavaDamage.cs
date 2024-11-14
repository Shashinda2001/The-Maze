using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaDamage : MonoBehaviour
{
    public float timeGap = 1f;
    private playerStatistic playerStatistic;
    void Start()
    {
        playerStatistic = FindAnyObjectByType<playerStatistic>();
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

              StartCoroutine(burning());
            playerStatistic.isDead = true;
          


        }
    }

     private IEnumerator burning()
     {
        
        yield return new WaitForSeconds(timeGap);
      }
}
