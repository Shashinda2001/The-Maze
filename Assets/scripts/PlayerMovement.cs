using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    Vector3 velocity;
    public float gravity = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3f;
    public float lowBoundary;
    

    bool life = true;

    void Start()
    {
        // Ensure the CharacterController component is assigned
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        // Check if the CharacterController component is assigned
        if (controller == null)
        {
            Debug.LogError("CharacterController component is not assigned.");
        }
    }

    void Update()
    {
        // Check if the CharacterController is enabled before calling Move
        if (controller != null && controller.enabled)
        {

            //ground ekeda balima
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            //gravity eka set 
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            //jump
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y -= gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("CharacterController is not enabled or not assigned.");
        }

        if (transform.position.y < lowBoundary)
        {
            life = false;
        }

        if (!life)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(1);
        }
    }
}
