using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePooler2 : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private Queue<GameObject> clonePool = new Queue<GameObject>();
    [SerializeField] private int poolSize;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(clonePrefab);
            clonePool.Enqueue(clone);
            clone.SetActive(false);
        }
    }

    public GameObject GetClone()
    {
        if (clonePool.Count > 0)
        {
            GameObject clone = clonePool.Dequeue();
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
        clonePool.Enqueue(clone);
        clone.SetActive(false);
    }
}
