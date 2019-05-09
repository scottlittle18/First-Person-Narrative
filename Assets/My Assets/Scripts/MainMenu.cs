using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///     This script is for the Main Menu buttons.
/// </summary>

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }

    public void PlayButtonClicked()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void CreditsButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
