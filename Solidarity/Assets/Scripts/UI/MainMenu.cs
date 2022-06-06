using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Method <c>PlayGame</c> loads the next scene from the main menu
    /// when clicking the "Play" button.
    /// </summary>
    public void PlayGame() 
    {
        Debug.Log("PlayGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnMainMenu()
    {
        Debug.Log("ReturnMainMenu");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
