using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //method to start game from main menu
    public void PlayGame()
    {
        //load game scene
        SceneManager.LoadScene("Maze");
    }

}
