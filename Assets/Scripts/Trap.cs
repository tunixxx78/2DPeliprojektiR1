using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject[] toSpawn;
    public Transform spawnLocation;

    public float minInterval = 1f, maxInterval = 2f;
    float _nextSpawnTime = 0f;

    public void Update()
    {
        // has enough time passed since last spawn?
        if (Time.time >= _nextSpawnTime)
        {
            // delay the next spawn time by a random amount
            _nextSpawnTime += Random.Range(minInterval, maxInterval);
            // select and instantiate a random prefab
            int randomIndex = Random.Range(0, toSpawn.Length);
            Instantiate(toSpawn[randomIndex], spawnLocation.position, Quaternion.identity);
        }
    }
}
