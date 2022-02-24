using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    void Update()
    {
        //if player passes a certain 2d position in maze win conditions met
        if (transform.position.x > 11.3f && transform.position.z > 7.7f)
        {
            //change to "you win" screen and unlock cursor
            SceneManager.LoadScene("Win");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
