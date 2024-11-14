using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class topbarControl : MonoBehaviour
{
    public float bombCount;  // Example variable
    public float hartcount;  // Example variable


    private Label displayCount; // Changed to Label for read-only display
    private grenadeThrow grenadeT;
    private PlayerInteraction iteract;
    private paintTrigger paints;

        private VisualElement _hartDisplay1;
    private VisualElement _hartDisplay2;

    private VisualElement _paint1;
    private VisualElement _paint2;
    private VisualElement _paint3;

         private bool paint1true=false;
         private bool paint2true=false;
         private bool paint3true=false;

    public Sprite[] backgroundImages;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();

        // Get the root VisualElement
        var root = uiDocument.rootVisualElement;

        // Find the Label by name
        displayCount = root.Q<Label>("bombCount"); // Changed to Label
        _hartDisplay1 = root.Q<VisualElement>("hart1");
        _hartDisplay2 = root.Q<VisualElement>("hart2");

        _paint1 = root.Q<VisualElement>("r1");
        _paint2 = root.Q<VisualElement>("r2");
        _paint3 = root.Q<VisualElement>("r3");

        // Find and assign the grenadeThrow script
        grenadeT = FindObjectOfType<grenadeThrow>();
        paints = FindObjectOfType<paintTrigger>();
        iteract = FindObjectOfType<PlayerInteraction>();
    }

    void Update()
    {
        // Check if grenadeT and displayCount are assigned
        if (grenadeT != null && displayCount != null)
        {
            // Update the bombCount and display it in the Label
            bombCount = grenadeT.bombCount;
            displayCount.text = bombCount.ToString(); // Changed from .value to .text
        }

        if(iteract !=null )
        {
            hartcount = iteract.hart;
           // Debug.Log(hartcount);
            if (hartcount == 2f)
            {
                _hartDisplay2.style.display = DisplayStyle.Flex;
                _hartDisplay1.style.display = DisplayStyle.Flex;

            }

            if (hartcount == 1f)
            {
                _hartDisplay2.style.display = DisplayStyle.None;
                _hartDisplay1.style.display = DisplayStyle.Flex;
            }

            if (hartcount == 0f)
            {
                _hartDisplay2.style.display = DisplayStyle.None;
                _hartDisplay1.style.display = DisplayStyle.None;
            }
        }

        if(paints != null)
        {

            paint1true = paints.paint1p2relic;
            paint2true = paints.paint2p1relic;
            paint3true = paints.paint2p2relic;
        }


        if (paint1true)
        {
            _paint1.style.backgroundImage = new StyleBackground(backgroundImages[0]);

        }

        if (paint2true)
        {
            _paint2.style.backgroundImage = new StyleBackground(backgroundImages[1]);

        }
        if (paint3true)
        {
            _paint3.style.backgroundImage = new StyleBackground(backgroundImages[2]);

        }
    }
}