using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCon1 : MonoBehaviour
{
    public GameObject targetObject; // The object to toggle
    public float timeGap = 2f; // Time gap between active and deactive states

    private bool isActive = true; // Track the current state of the object

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject != null)
        {
            StartCoroutine(ToggleActiveState());
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    private IEnumerator ToggleActiveState()
    {
        while (true) // Infinite loop to keep toggling
        {
            isActive = !isActive; // Toggle the state
            targetObject.SetActive(isActive); // Apply the state to the object

            yield return new WaitForSeconds(timeGap); // Wait for the specified time gap
        }
    }
}
