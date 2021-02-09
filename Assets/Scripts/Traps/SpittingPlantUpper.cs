using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpittingPlantUpper : trapUpper
{
    [SerializeField] private float delayTime = 10f, timeToSpawn = 1f;
    private float timeSinceSpawn;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(delayTime);
    }

    private void Update()
    {
        if (distanceOfPlayer <= attackRange)
        {
            Instantiate(ammoPrefab, spawnPointForTrap.position, Quaternion.identity);
        }
    }
}
