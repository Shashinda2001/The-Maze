using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerUIroute : MonoBehaviour
{
    private PuzzleManager1 puzzleManager;


    public GameObject lineOne;
    public GameObject lineTwo;

    public GameObject acessUI;

    public GameObject selectUI;
    private bool check =true;
    private bool check1 = true;

    public GameObject uiX;
    public GameObject uiY;

    public bool locker = false;
    public bool elavator = false;
    void Start()
    {
        lineOne.SetActive(false);
        lineTwo.SetActive(false);
        acessUI.SetActive(false);
        selectUI.SetActive(false);
        uiX.SetActive(false);
        uiY.SetActive(false);

        puzzleManager = FindAnyObjectByType<PuzzleManager1>();

        if (puzzleManager == null)
        {
            Debug.Log("script not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(puzzleManager.IspuzzleComplete)
        {
            if (check1)
            {
                acessUI.SetActive(true);
                StartCoroutine(disableAessUI());
            }
                

            if (check)
            {
                
                selectUI.SetActive(true);
            }
            
           

            if (Input.GetKeyDown(KeyCode.X)) {
                selectUI.SetActive(false);
                uiX.SetActive(true);
                uiY.SetActive(false);
                check = false;
                locker = true;
                elavator = false;
                lineOne.SetActive(true);
                lineTwo.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Y)) {
                selectUI.SetActive(false);
                uiX.SetActive(false);
                uiY.SetActive(true);
                check = false;
                locker = false;
                elavator = true;
                lineOne.SetActive(false);
                lineTwo.SetActive(true);
            }
        }
      
    }

    private IEnumerator disableAessUI()
    {
        yield return new WaitForSeconds(2f);
        acessUI.SetActive(false);
        check1 = false;
       
    }

    
}
