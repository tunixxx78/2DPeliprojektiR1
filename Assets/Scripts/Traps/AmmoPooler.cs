using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPooler : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Queue<GameObject> ammoPool = new Queue<GameObject>();
    [SerializeField] private int poolSize;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(ammoPrefab);
            ammoPool.Enqueue(clone);
            clone.SetActive(false);
        }
    }

    public GameObject GetClone()
    {
        if (ammoPool.Count > 0)
        {
            GameObject clone = ammoPool.Dequeue();
            clone.SetActive(true);
            return clone;
        }
        else
        {
            //GameObject clone = Instantiate(clonePrefab);
            return null;
        }
    }

    public void ReturnClone(GameObject clone)
    {
        ammoPool.Enqueue(clone);
        clone.SetActive(false);
    }
}
