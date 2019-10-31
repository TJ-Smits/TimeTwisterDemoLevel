using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float jumpHeight = 1.0f;

    public float defaultSpeed = 3.0f;

    public float runningSpeedMultiplier = 2.0f;

    public float gravity = -9.81f;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsCharacterGrounded();

        ResetGravityWhenNearGround();

        Move();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        ApplyGravity();
    }

    private bool IsCharacterGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void Move()
    {
        // Obtain the axes inputs
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        float speed = defaultSpeed;
        if (Input.GetButton("Run"))
        {
            speed *= runningSpeedMultiplier;
        } else
        {
            speed = defaultSpeed;
        }

        controller.Move(move * speed * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

    private void ResetGravityWhenNearGround()
    {
        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
