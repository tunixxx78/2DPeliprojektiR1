using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSounds : MonoBehaviour
{
    public void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", GetComponent<Transform>().position);
    }
    
}
