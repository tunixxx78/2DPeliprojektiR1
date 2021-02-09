using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private AmmoPooler ammoPool;
    [SerializeField] private float delayTime;
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(delayTime);
        //ammoPool = FindObjectOfType<AmmoPooler>();
    }

    private void Update()
    {

        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= timeToSpawn/* && ammoPool != null*/)
        {
            Instantiate(ammoPrefab, spawnPoint.position, Quaternion.identity);
            timeSinceSpawn = 0f;
            /*GameObject newClone = ammoPool.GetClone();
            if (newClone != null)
            {
                newClone.transform.position = this.transform.position;
                timeSinceSpawn = 0f;
            }*/
        }
        
    }
}
