using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentClone : MonoBehaviour
{
    [SerializeField]
    GameObject[] clonesToUnparent;
   public void Unparent()
    {
        for (int i = 0; i < clonesToUnparent.Length; i++)
        {
            clonesToUnparent[i].transform.parent = null;
            Destroy(clonesToUnparent[i], 3);

        }
    }
}
