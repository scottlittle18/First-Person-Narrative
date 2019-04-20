using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///     This script is for the Main Menu buttons.
/// </summary>

public class MainMenu : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        //int currentScene = SceneManager.GetActiveScene().buildIndex;

        //SceneManager.LoadScene(currentScene + 1);
        //TODO: Debug
        Debug.Log("Start Button Clicked!");
    }

    public void ExitButtonClicked()
    {
        //TODO: Debug Quit
        Debug.Log("Quit!");
        Application.Quit();
    }
}
