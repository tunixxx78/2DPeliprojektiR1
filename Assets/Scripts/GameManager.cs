﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    [SerializeField] private GameObject restartPoint;
    [SerializeField] private Transform player;
    public GameObject endFade;

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
        player.transform.position = restartPoint.transform.position;
    }
    public void ZeroHealth()
    {
        Invoke("GameOver", 2f);
    }

    public void TimeHasRunOut()
    {
        SceneManager.LoadScene("RunOutOfTime");
        Debug.Log("TIME RUN OUT!!!");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
