using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    [SerializeField] private GameObject restartPoint;
    [SerializeField] private Transform player;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("END GAME");
        }
        
    }

    public void Restart()
    {
        player.transform.position = restartPoint.transform.position;
    }
}
