using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{ 
    public void ActionButtonPressed()
    {
        Debug.Log("PRESSS");
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(3);
    }
}
