using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frameratelimiter : MonoBehaviour
{
    public int maxFrames = 60;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = maxFrames;
    }
}
