using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoringSystem.theScore = (int)0f;
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Tutorial");
        ScoringSystem.theScore = (int)0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
