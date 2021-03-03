using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    private FMOD.Studio.EventInstance music;
    [FMODUnity.BankRef] public string musicEvent;

    [SerializeField] [Range(0f, 1f)] private float state;

    private void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        music.start();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndZone"))
        {
            music.setParameterByName("endFade", 1f);
            Debug.Log("OSUMA");
        }
        
    }

   
}
