using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; // Required for scene management

public class loose : MonoBehaviour
{
    

    private Button _play;
    private Button _exit;
    

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

         

        _play = root.Q<Button>("play");
        _exit = root.Q<Button>("exit");
        

         

        _play.RegisterCallback<ClickEvent>(onPlay);
        _exit.RegisterCallback<ClickEvent>(onExist);
         
    }

    private void onPlay(ClickEvent evt)
    {
        SceneManager.LoadScene(0); // Load scene 0
    }

     

    private void onExist(ClickEvent evt)
    {
        SceneManager.LoadScene(3); // Load scene 3
    }


     

    
}