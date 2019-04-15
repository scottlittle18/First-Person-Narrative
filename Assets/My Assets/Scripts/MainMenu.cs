using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }

    public void CreditsButtonClicked()
    {
        //SceneManager.LoadScene("CreditsScene");
    }

    public void ExitButtonClicked()
    {
        //TODO: Debug Quit
        Debug.Log("Quit!");
        Application.Quit();
    }
}
