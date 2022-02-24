using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    //set look sensitivity for player
    public float playerSensitivity = 200f;

    //position variable for turn when look
    public Transform playerBody;


    float xRotation = 0f;

    void Start()
    {
        //maintains cursor within game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        //get axis input from mouse
        float mouseX = Input.GetAxis("Mouse X") * playerSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * playerSensitivity * Time.deltaTime;

        //clamps rotation in y axis to stop look inversion
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);

        //rotates camera and player in x axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
