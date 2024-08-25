using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingOneWay : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }


}
