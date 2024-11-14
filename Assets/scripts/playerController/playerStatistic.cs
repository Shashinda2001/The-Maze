using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStatistic : MonoBehaviour
{
    public int bloodLevel = 100;
    public bool isDead = false;
    public float timeGap = 3f;
    void Start()
    {
        bloodLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (bloodLevel <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            Debug.Log("player dead");
            StartCoroutine(playAgain());
           
        }
        

    }
    private IEnumerator playAgain()
    {
        yield return new WaitForSeconds(timeGap);
        SceneManager.LoadScene(1);
    }


}
