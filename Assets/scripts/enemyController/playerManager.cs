using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton

    public static playerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
