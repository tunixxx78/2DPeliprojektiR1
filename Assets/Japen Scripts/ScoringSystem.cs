using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText;
    public static int theScore;

    void Update()
        {
            scoreText.GetComponent<Text>().text = "" + theScore;

            if (theScore > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", theScore);

                }
            
        }
    
    
}
