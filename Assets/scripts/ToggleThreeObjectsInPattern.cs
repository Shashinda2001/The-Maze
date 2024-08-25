using System.Collections;
using UnityEngine;

public class ToggleThreeObjectsInPattern : MonoBehaviour
{
    public GameObject[] objects; // Array of objects to toggle
    public float timeGap = 2f;   // Time gap between toggles

    private int currentIndex = 0; // Track the current object index

    // Start is called before the first frame update
    void Start()
    {
        if (objects.Length == 3)
        {
            StartCoroutine(ToggleObjectsInPattern());
        }
        else
        {
            Debug.LogError("Please assign exactly 3 objects.");
        }
    }

    private IEnumerator ToggleObjectsInPattern()
    {
        while (true)
        {
            // Deactivate all objects initially
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            // Activate the current object and the next object in a circular manner
            objects[currentIndex].SetActive(true);
            objects[(currentIndex + 1) % objects.Length].SetActive(true);

            // Wait for the specified time gap
            yield return new WaitForSeconds(timeGap);

            // Move to the next index
            currentIndex = (currentIndex + 1) % objects.Length;
        }
    }
}
