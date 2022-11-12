using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public Transform headCheck;

    public float groundDistance = 1;
    public float headDistance = 1;
    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;


    public LayerMask groundMask;

    Vector3 velocity;

    bool isgrounded;
    bool headBounce;

    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        headBounce = Physics.CheckSphere(headCheck.position, headDistance, groundMask);

        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (headBounce && velocity.y > 0.1)
        {
            velocity.y = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}