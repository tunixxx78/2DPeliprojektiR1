using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
   

    private void Start()
    {
       FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndZone"))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("endFade", 1f);
            Debug.Log("OSUMA");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("EndZone"))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("endFade", 0f);
            Debug.Log("POISTUI");
        }
       
    }
}
