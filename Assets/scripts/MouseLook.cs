using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivly = 100f;
    public Transform playerBody;
    float xRotation =0f;

    public GameObject pauseUI;
   public bool isPaused = false;

    void Start()
    {
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivly * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivly * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70f, 50f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseUI.SetActive(isPaused);
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            Debug.Log("Menu " + (isPaused ? "activated" : "closed") + ". pauseUI active: " + pauseUI.activeSelf);
        }


    }
}
