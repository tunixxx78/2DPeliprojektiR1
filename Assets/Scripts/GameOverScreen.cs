using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Turo");
    }

    public void TryAgainSameLevel ()
    {
        
        SceneManager.LoadScene("Turo");
    }

    public void QuitGame ()
    {
        SceneManager.LoadScene("Credits");
    }
}
