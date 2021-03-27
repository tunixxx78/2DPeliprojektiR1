using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
    public Text highScore, yourScore;
    [SerializeField] private GameObject currentScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //currentScore.GetComponent<Text>().text = "" + yourScore;
        yourScore.text = ScoringSystem.theScore.ToString();
    }

    public void ZeroScore()
    {
        highScore.text = "0";
    }
}
