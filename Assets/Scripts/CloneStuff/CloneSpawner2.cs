using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner2 : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ClonePooler2 clonePool;
    [SerializeField] private float delayTime;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(delayTime);
        clonePool = FindObjectOfType<ClonePooler2>();
    }

    private void Update()
    {
        
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= timeToSpawn && clonePool != null)
        {
            GameObject newClone = clonePool.GetClone();
            if (newClone != null)
            {
                newClone.transform.position = this.transform.position;
                timeSinceSpawn = 0f;
            }
        }
    }
}
