 
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class menuBackground : MonoBehaviour
{
    // Array to hold your background images
    public Sprite[] backgroundImages;
    public float changeInterval = 2f; // Time between image changes

    private VisualElement backgroundElement;
    private int currentImageIndex = 0;
    private float timer = 0f;

    void Start()
    {
        // Reference to the UI document
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        // Find the VisualElement in your UI
        backgroundElement = rootVisualElement.Q<VisualElement>("display");

        if (backgroundElement != null && backgroundImages.Length > 0)
        {
            // Set the initial background image
            SetBackgroundImage(currentImageIndex);
        }
    }

    void Update()
    {
        if (backgroundElement == null || backgroundImages.Length == 0)
            return;

        // Update the timer
        timer += Time.deltaTime;

        // If the timer exceeds the interval, switch to the next image
        if (timer >= changeInterval)
        {
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Length; // Loop through images
            SetBackgroundImage(currentImageIndex);
            timer = 0f; // Reset the timer
        }
    }

    void SetBackgroundImage(int index)
    {
        // Assuming you are using the background image as a style background
        backgroundElement.style.backgroundImage = new StyleBackground(backgroundImages[index]);
    }
}
