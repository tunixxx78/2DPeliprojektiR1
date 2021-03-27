using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreScreen : MonoBehaviour
{
    public void StartAgain()
    {
        SceneManager.LoadScene("Turo");
        ScoringSystem.theScore = (int) 0f;
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        FindObjectOfType<HighScoreSystem>().ZeroScore();
    }
}
