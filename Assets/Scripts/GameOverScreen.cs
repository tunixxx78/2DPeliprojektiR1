using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
   public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoringSystem.theScore = (int)0f;
        //SceneManager.LoadScene("Turo");
    }

    public void TryAgainSameLevel ()
    {
        
        SceneManager.LoadScene("Turo");
    }

    public void QuitGame ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }
}
