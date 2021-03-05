using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce, arrowLifeSpan = 0.5f; //Turo lisäsi arrowlifespan muuttujan.
    public Transform shotPoint;
    
    
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBeetweenPoints;
    Vector2 direction;



    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            
            FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot", GetComponent<Transform>().position);
            Shoot();

        }
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBeetweenPoints);
        }
      
    }
    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.up * launchForce;
        Destroy(newArrow, arrowLifeSpan);  //Turo lisännyt -> tuhoaa nuolen määritetyn ajan kuluttua.
    }

    
    
    Vector2 PointPosition(float t) 
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    
}
