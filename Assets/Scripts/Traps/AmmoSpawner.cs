using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    [SerializeField] private float delayTime;
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force = 1f;

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

        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= timeToSpawn)
        {
            //Shoot();
            Instantiate(ammoPrefab, spawnPoint.position, Quaternion.identity);
            timeSinceSpawn = 0f;
           
        }
        
    }
    /*private void Shoot()
    {
        GameObject newAmmoPrefa = Instantiate(ammoPrefab, spawnPoint.position, Quaternion.identity);
        newAmmoPrefa.GetComponent<Rigidbody2D>().velocity = -transform.right * force;
    }*/
}
