using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{ 
    public void ActionButtonPressed()
    {
        Debug.Log("PRESSS");
        SceneManager.LoadScene(0);
    }
}
