using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    [SerializeField] private GameObject restartPoint;
    [SerializeField] private Transform player;
    public GameObject endFade, gameOver, timeOver;

    public void EndGame()
    {
        endFade.SetActive(true);
        
        Invoke("StartNewLevel", 4f);
        
        /*if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("END GAME");
        }*/
        
    }

    private void StartNewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        if (player != null)
        {
            player.transform.position = restartPoint.transform.position;
        }
    }
    public void ZeroHealth()
    {
        gameOver.SetActive(true);
        //Invoke("GameOver", 2f);
    }

    public void TimeHasRunOut()
    {
        timeOver.SetActive(true);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
