using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateTiles : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject thrusterPrefab;
    public Camera mainCamera;

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
    void Update()
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
