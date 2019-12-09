using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTiles : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject thrusterPrefab;
    public Camera mainCamera;
    void Start()
    {
        float xStand = 0.32f;
        float yStand = 0.32f;
        Instantiate(tilePrefab, transform.position + new Vector3(0, 0), transform.rotation, transform);
        Instantiate(tilePrefab, transform.position + new Vector3(xStand, 0), transform.rotation, transform);
        Instantiate(tilePrefab, transform.position + new Vector3(0, yStand), transform.rotation, transform);
        Instantiate(tilePrefab, transform.position + new Vector3(xStand, yStand), transform.rotation, transform);        
    }

    public float NearestMultiple(float multipleOf,  float inValue)
    {
        float lower = inValue - (inValue % multipleOf);
        float upper;

        if (inValue < 0)
        {
            upper = (inValue - (inValue % multipleOf)) - multipleOf;
        }
        else
        {
            upper = (inValue - (inValue % multipleOf)) + multipleOf;
        }

        if (Mathf.Abs(upper - inValue) < Mathf.Abs(inValue - lower))
        {
            return upper;
        }
        else
        {
            return lower;
        }
    }
    void FixedUpdate()
    {         
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 placePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            placePos.z = 0;
            placePos.x = NearestMultiple(0.32f, placePos.x);
            placePos.y = NearestMultiple(0.32f, placePos.y);
            Instantiate(tilePrefab, placePos, transform.rotation, transform);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 placePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            placePos.z = 0;
            placePos.x = NearestMultiple(0.32f, placePos.x);
            placePos.y = NearestMultiple(0.32f, placePos.y);
            Instantiate(thrusterPrefab, placePos, transform.rotation, transform);
        }
    }
}
