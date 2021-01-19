using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycasting : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer LineRenderer;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {
        // shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            LineRenderer.SetPosition(0, firePoint.position);
            LineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            LineRenderer.SetPosition(0, firePoint.position);
            LineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        LineRenderer.enabled = true;

        yield return 0;

        LineRenderer.enabled = false;
    }
}
