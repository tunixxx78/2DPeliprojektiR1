using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    //  ↓ Path point
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBeetweenPoints;
    // ↓ Line 17 poista jos Path point ei käytössä
    Vector2 direction;



    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    //  ↑

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ↓ Line 37 lisää vector2 jos Path Point ei käytössä.
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //  ↓ Path Point code
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBeetweenPoints);
        }
        //  ↑
    }
    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
    
    //  ↓ Path Point code

    Vector2 PointPosition(float t) {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
    
    //  ↑
}
