using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateController : MonoBehaviour
{
    private Animator animator;
    private int isSawHash;

    

    private enemyController enemy;  // Reference to the parent enemyController

    void Start()
    {
        animator = GetComponent<Animator>();
        isSawHash = Animator.StringToHash("isSaw");
       

        // Find the enemyController component on the parent GameObject
        enemy = GetComponentInParent<enemyController>();

        if (enemy == null)
        {
            Debug.LogWarning("enemyController not found in parent of " + gameObject.name);
        }
    }

    void Update()
    {
        
        if (enemy != null && enemy.isSaw)
        {
            animator.SetBool(isSawHash, true);
        }
        else
        {
            animator.SetBool(isSawHash, false);
        }
        
       
    }
}