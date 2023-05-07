using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainSceneDemo");
        GUITimer.ResetTimer();
    }

    public void StartInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
