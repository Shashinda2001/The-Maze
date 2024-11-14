using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int blood;
    //public float timeGap = 2f;


    public playerStatistic playerStatistic;
    void Start()
    {
        playerStatistic = FindAnyObjectByType<playerStatistic>();

        if (playerStatistic == null)
        {
            Debug.Log("not found");
        }
        
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
            
            //  StartCoroutine(reduceBlood());
            Debug.Log(playerStatistic.bloodLevel);
            playerStatistic.bloodLevel--;
           // blood--;

            
        }
    }

   // private IEnumerator reduceBlood()
   // {
   //     Debug.Log("enemy attacked");
    //    blood--;
    //    yield return new WaitForSeconds(timeGap);
  //  }
}
