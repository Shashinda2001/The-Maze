using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public float lookRadius = 10f;  // Radius within which the enemy will chase the player
    public float wanderTimer = 1f;   // Time interval between random wander movements
    public float wanderRadius = 50f;  // Radius within which the enemy will randomly wander
    public float minDistance = 10f;   // Minimum distance to check for a new random position

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private float originalLookRadius; // Store the original look radius

    public bool isSaw = false;

    public bool isStop = false;

    private hideOutController hideOut;  // Reference to hideOutController component

    void Start()
    {
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        originalLookRadius = lookRadius; // Store the original value
        timer = wanderTimer;

        // Find the hideOutController component in the scene
        hideOut = FindObjectOfType<hideOutController>();

        if (hideOut == null)
        {
            Debug.LogWarning("hideOutController not found in the scene.");
        }
    }

    void Update()
    {
        //Debug.Log(hideOut.playerHide);
        bool checkHide = hideOut.playerHide;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && !checkHide)
        {
            isSaw = true;
            // Player is within look radius, chase the player
            agent.SetDestination(target.position);

            // Double the look radius when the player is detected
            if (lookRadius != originalLookRadius * 2)
            {
                lookRadius = originalLookRadius * 2;
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else if (isSaw && distance <= lookRadius)
        {
            isSaw = true;
            // Player is within look radius, chase the player
            agent.SetDestination(target.position);

            // Double the look radius when the player is detected
            if (lookRadius != originalLookRadius * 2)
            {
                lookRadius = originalLookRadius * 2;
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            isSaw = false;
            // Restore the original look radius when the player is out of range
            if (lookRadius != originalLookRadius)
            {
                lookRadius = originalLookRadius;
            }

            // Wander randomly when player is out of range
            timer += Time.deltaTime;

            // Check if agent has reached its current destination
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (timer >= wanderTimer)
                {
                    Vector3 newPos;
                    do
                    {
                        // Generate a new random position
                        newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    }
                    while (Vector3.Distance(transform.position, newPos) < minDistance); // Ensure new position is far enough

                    agent.SetDestination(newPos);
                    timer = 0;
                }
                // Check if the agent has stopped
                if (agent.remainingDistance <= agent.stoppingDistance && agent.velocity.magnitude < 0.1f)
                {
                  //  Debug.Log("Enemy has stopped moving.");
                    isStop = true;
                }
                else
                {
                    //Debug.Log("Enemy has  moving.");
                    isStop = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);  // Visualize the look radius
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Helper method to get a random point on the NavMesh
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}