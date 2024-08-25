using System.Collections;
using UnityEngine;

public class ToggleFiveObjectsInPattern : MonoBehaviour
{
    public GameObject[] objects; // Array of objects to toggle
    public float timeGap = 2f;   // Time gap between toggles

    private int currentPatternIndex = 0; // Track the current pattern index

    // Define the activation patterns (pairs of indices)
    private int[,] activationPatterns = new int[,]
    {
        { 0, 1 }, // First pattern
        { 2, 3 }, // Second pattern
        { 1, 4 }, // Third pattern
        { 0, 3 }, // Fourth pattern
        { 2, 4 }, // Fifth pattern
        // Add more complex patterns as needed
    };

    // Start is called before the first frame update
    void Start()
    {
        if (objects.Length == 5)
        {
            StartCoroutine(ToggleObjectsInComplexPattern());
        }
        else
        {
            Debug.LogError("Please assign exactly 5 objects.");
        }
    }

    private IEnumerator ToggleObjectsInComplexPattern()
    {
        while (true)
        {
            // Deactivate all objects initially
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            // Activate the objects based on the current pattern
            int firstObjectIndex = activationPatterns[currentPatternIndex, 0];
            int secondObjectIndex = activationPatterns[currentPatternIndex, 1];

            objects[firstObjectIndex].SetActive(true);
            objects[secondObjectIndex].SetActive(true);

            // Wait for the specified time gap
            yield return new WaitForSeconds(timeGap);

            // Move to the next pattern in the sequence
            currentPatternIndex = (currentPatternIndex + 1) % activationPatterns.GetLength(0);
        }
    }
}
