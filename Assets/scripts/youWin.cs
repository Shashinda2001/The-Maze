using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youWin : MonoBehaviour
{
    // Start is called before the first frame update
    bool win = false;
    public float lap;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("you win");
        if (!win)
        {
            Cursor.lockState = CursorLockMode.None;
            win = true;
            StartCoroutine(LoadSceneAfterDelay(lap));
            
           
        }
 

    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }
}
