using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; // Required for scene management

public class win : MonoBehaviour
{

    private Button _continue;
    private Button _play;
    private Button _exit;


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;


        _continue = root.Q<Button>("continue");
        _play = root.Q<Button>("play-again");
        _exit = root.Q<Button>("exit");



        _continue.RegisterCallback<ClickEvent>(onPlay);
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