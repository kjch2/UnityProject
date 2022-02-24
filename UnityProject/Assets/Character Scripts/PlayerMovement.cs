using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;      //reference to character controller 

    public float speed = 12f;                   //movement speed for player                                                              
    public float gravity = -9.81f;              //gravitational acceleration                                                           
    public float jumpHeight = 3f;               //jump height for player

    public Transform groundCheck;               //references ground check object
    public float groundDistance = 0.4f;         //sets distance to check for ground
    public LayerMask groundMask;                //checks for ground layer only

    Vector3 velocity;                           //stores current velocity
    bool isGrounded;                            //stores if player is grounded or not

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);     //checks if player object is grounded and sets isGrounded 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;                                               //if grounded is true reset velocity to -2
        }

        float x = Input.GetAxis("Horizontal");                              //collects input for horizontal movement                                              
        float z = Input.GetAxis("Vertical");                                //collects input for vertical movement

        Vector3 move = transform.right * x + transform.forward * z;         //sets movement direction to be forward in the direction the player is facing

        controller.Move(move * speed * Time.deltaTime);                     //drives player movement independant of framerate

        if (Input.GetButtonDown("Jump") && isGrounded)                      //checks for jump input
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);            //calculates the amount fo velocity need to jump the required height
        }

        velocity.y += gravity * Time.deltaTime;                             //adds increase in gravitational velocity 

        controller.Move(velocity * Time.deltaTime);                         //implements acceleration on player
    }
}
