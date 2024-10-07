using System.Collections;
using System.Collections.Generic;
 
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; // Required for scene management

public class pauseControl : MonoBehaviour
{
    private VisualElement _control;
    public GameObject pauseUI;
    private Button _play;
    private Button _exit;
    private Button _option;
    private Button _continue;

    private MouseLook mouseLook; // Reference to MouseLook script

   
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        var root = GetComponent<UIDocument>().rootVisualElement;

        _control = root.Q<VisualElement>("controlBody");
       

 

        _play = root.Q<Button>("new-game");
        _exit = root.Q<Button>("exit");
        _option = root.Q<Button>("control");
        _continue = root.Q<Button>("continue");

        _control.style.display = DisplayStyle.None;
         

        _play.RegisterCallback<ClickEvent>(onPlay);
        _exit.RegisterCallback<ClickEvent>(onExit);
        _option.RegisterCallback<ClickEvent>(onOption);
        _continue.RegisterCallback<ClickEvent>(onContinue);

        // Find and assign the MouseLook script
        mouseLook = FindObjectOfType<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onPlay(ClickEvent evt)
    {
        _control.style.display = DisplayStyle.None;
        SceneManager.LoadScene(3); // Load scene 3
    }

    private void onContinue(ClickEvent evt)
    {
        _control.style.display = DisplayStyle.None;
        if (mouseLook != null)
        {
            mouseLook.isPaused = false; // Unpause the game
        }
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Debug.Log("CONTUNE PRESS");
       
    }

    private void onExit(ClickEvent evt)
    {
        _control.style.display = DisplayStyle.None;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#else
        Application.Quit(); // Quit the game
#endif

    }

    private void onOption(ClickEvent evt)
    {
        _control.style.display = DisplayStyle.Flex;
       
    }
}
