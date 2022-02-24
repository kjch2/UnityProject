using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapsuleImpact : MonoBehaviour
{
    //on collision method
    void OnCollisionEnter(Collision impact)
    {
        //if the game object collides with anything with "Capsule" tag then lose conditions met
        if (impact.gameObject.tag == "Capsule")
        {
            //load game over scene and unlock cursor 
            SceneManager.LoadScene("Game Over");
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
