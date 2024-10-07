using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintTrigger : MonoBehaviour
{
   public bool paint2p1relic = false;
   public  bool paint2p2relic = false;
    bool door2 = false;

    public GameObject paintoneP2c1;
    public GameObject paintoneP2c2;

    public  bool paint1p2relic = false;
    bool door1 = false;

    public GameObject paintonePc1;
    public float moveSpeed = 8f; // Speed at which the object moves on the Y-axis
    public float moveDuration = 3f; // Duration for which the object moves

    private GameObject puzzle1Object;
    private GameObject puzzle1Object2;
    private float moveTime = 0f; // Timer for movement duration
    private float moveTime1 = 0f; // Timer for movement duration

    // Start is called before the first frame update
    void Start()
    {
        paintonePc1.SetActive(false);
        paintoneP2c1.SetActive(false);
        paintoneP2c2.SetActive(false);

        // Find the object with the tag "puzzle1" and store it in the variable
        puzzle1Object = GameObject.FindGameObjectWithTag("puzzle1");

        // Find the object with the tag "puzzle2" and store it in the variable
        puzzle1Object2 = GameObject.FindGameObjectWithTag("puzzle2");
    }

    // Update is called once per frame
    void Update()
    {
        // Move puzzle1Object
        if (door1 && puzzle1Object != null && moveTime < moveDuration)
        {
            Vector3 targetPosition = puzzle1Object.transform.localPosition;
            targetPosition.y += moveSpeed * Time.deltaTime;
            puzzle1Object.transform.localPosition = targetPosition;

            moveTime += Time.deltaTime;
        }

        // Move puzzle1Object2
        if (door2 && puzzle1Object2 != null && moveTime1 < moveDuration)
        {
            Vector3 targetPosition2 = puzzle1Object2.transform.localPosition;
            targetPosition2.y += moveSpeed * Time.deltaTime;
            puzzle1Object2.transform.localPosition = targetPosition2;

            moveTime1 += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the collided object has the tag "paint1p2"
        if (other.gameObject.CompareTag("paint1p2"))
        {
            Debug.Log("paint1p2 found");

            if (Input.GetKeyDown(KeyCode.E) && !paint1p2relic)
            {
                paint1p2relic = true;
                Destroy(other.gameObject, 2f); // Fixed destroy delay
            }
        }

        // Check if the collided object has the tag "paint2p1"
        if (other.gameObject.CompareTag("paint2p1"))
        {
            Debug.Log("paint2p1 found");

            if (Input.GetKeyDown(KeyCode.E) && !paint2p1relic)
            {
                paint2p1relic = true;
                Destroy(other.gameObject, 2f); // Fixed destroy delay
            }
        }

        // Check if the collided object has the tag "paint2p2"
        if (other.gameObject.CompareTag("paint2p2"))
        {
            Debug.Log("paint2p2 found");

            if (Input.GetKeyDown(KeyCode.E) && !paint2p2relic)
            {
                paint2p2relic = true;
                Destroy(other.gameObject, 2f); // Fixed destroy delay
            }
        }

        // Check if the collided object has the tag "puzzle1"
        if (other.gameObject.CompareTag("puzzle1"))
        {
            Debug.Log("puzzle one");

            if (Input.GetKeyDown(KeyCode.E) && paint1p2relic)
            {
                paintonePc1.SetActive(true);
                door1 = true; // Set door1 to true when the condition is met
                moveTime = 0f; // Reset the move timer when movement starts
            }
        }

        // Check if the collided object has the tag "puzzle2"
        if (other.gameObject.CompareTag("puzzle2"))
        {
            Debug.Log("puzzle two");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (paint2p2relic)
                {
                    paintoneP2c2.SetActive(true);
                }
                if (paint2p1relic)
                {
                    paintoneP2c1.SetActive(true);
                }

                if (paint2p2relic && paint2p1relic)
                {
                    door2 = true; // Set door2 to true when both relics are collected
                    moveTime1 = 0f; // Reset the move timer when movement starts
                }
            }
        }
    }

    private IEnumerator ScaleDownAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        // Destroy(gameObject, destroyDelay);
    }
}
