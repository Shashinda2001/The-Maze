using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; // Required for scene management

public class uicontroller : MonoBehaviour
{

    // URL of the GitHub repository
    public string githubURL = "https://github.com/Shashinda2001";
    // URL of the GitHub repository
    public string lkdURL = "www.linkedin.com/in/shashinda-adithya-31b227253";
    // URL of the GitHub repository
    public string ichiuURL = "https://shashinda.itch.io";

    private VisualElement _controlls;
    private VisualElement _info;

    private Button _play;
    private Button _exit;
    private Button _option;
    private Button _credit;

    //social media
    private Button _git;
    private Button _lkd;
    private Button _ichi;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _controlls = root.Q<VisualElement>("controls");
        _info = root.Q<VisualElement>("info");


        _git = root.Q<Button>("gitnav");
        _lkd = root.Q<Button>("linkedin");
        _ichi = root.Q<Button>("ichi");

        _play = root.Q<Button>("play");
        _exit = root.Q<Button>("exit");
        _option = root.Q<Button>("options");
        _credit = root.Q<Button>("credit");

        _controlls.style.display = DisplayStyle.None;
        _info.style.display = DisplayStyle.None;

        _play.RegisterCallback<ClickEvent>(onPlay);
        _exit.RegisterCallback<ClickEvent>(onExit);
        _option.RegisterCallback<ClickEvent>(onOption);
        _credit.RegisterCallback<ClickEvent>(onCredit);

        //social
        _git.RegisterCallback<ClickEvent>(navGit);
        _ichi.RegisterCallback<ClickEvent>(navIchi);
        _lkd.RegisterCallback<ClickEvent>(navLkd);
    }

    private void navGit(ClickEvent evt)
    {
        Application.OpenURL(githubURL);
    }

    private void navIchi(ClickEvent evt)
    {
        Application.OpenURL(ichiuURL);
    }

    private void navLkd(ClickEvent evt)
    {
        Application.OpenURL(lkdURL);
    }
    ///

    private void onPlay(ClickEvent evt)
    {
        SceneManager.LoadScene(0); // Load scene 0
    }

    private void onCredit(ClickEvent evt)
    {
        _info.style.display = DisplayStyle.Flex;
        _controlls.style.display = DisplayStyle.None;
    }


    private void onExit(ClickEvent evt)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#else
        Application.Quit(); // Quit the game
#endif
    }


    private void onOption(ClickEvent evt)
    {
        _info.style.display = DisplayStyle.None;
        _controlls.style.display = DisplayStyle.Flex;
    }

    // Update is called once per frame
}