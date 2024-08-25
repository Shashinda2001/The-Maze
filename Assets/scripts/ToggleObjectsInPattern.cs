using System.Collections;
using UnityEngine;

public class ToggleObjectsInPattern : MonoBehaviour
{
    public GameObject[] objects; // Array of objects to toggle
    public float timeGap = 2f;   // Time gap between toggles

    private int currentPairIndex = 0; // Track the current pair index

    // Start is called before the first frame update
    void Start()
    {
        if (objects.Length == 4)
        {
            StartCoroutine(ToggleObjectsInPairs());
        }
        else
        {
            Debug.LogError("Please assign exactly 4 objects.");
        }
    }

    private IEnumerator ToggleObjectsInPairs()
    {
        while (true)
        {
            // Deactivate all objects initially
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            // Activate the current pair of objects
            objects[currentPairIndex].SetActive(true);
            objects[(currentPairIndex + 1) % objects.Length].SetActive(true);

            // Wait for the specified time gap
            yield return new WaitForSeconds(timeGap);

            // Move to the next pair of objects
            currentPairIndex = (currentPairIndex + 2) % objects.Length;
        }
    }
}
