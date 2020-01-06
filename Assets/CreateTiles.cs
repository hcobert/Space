using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateTiles : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject thrusterPrefab;
    public Camera mainCamera;

    string selected = "unselected";
    bool cantPlace;
    Quaternion currentRotation;
    float currentRotationZ = 0;
    string sendKey;
    void Start()
    {
        currentRotation = transform.rotation;
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
    public void TileSelected()
    {
        selected = "tile";
    }
    public void ThrusterSelected()
    {
        selected = "thruster";
    }
    public void CantPlace(bool inCantPlace)
    {
        cantPlace = inCantPlace;
    }
    public void SendKey(string inKey)
    {
        sendKey = inKey;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentRotationZ += 90;
            currentRotation = transform.rotation;
            currentRotation.SetEulerAngles(0,0,currentRotationZ * Mathf.Deg2Rad);
        }
        if (Input.GetMouseButtonDown(0) && (cantPlace == false))
        {
            Vector3 placePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            placePos.z = 0;
            placePos.x = NearestMultiple(0.32f, placePos.x);
            placePos.y = NearestMultiple(0.32f, placePos.y);
            //place basic tile
            if (selected == "tile")
            {                
                Instantiate(tilePrefab, placePos, currentRotation, transform);
            }
            //place thruster
            else if (selected == "thruster")
            {                
                Instantiate(thrusterPrefab, placePos, currentRotation, transform);
                transform.GetChild(transform.childCount - 1).SendMessage("ActiveKey",sendKey,SendMessageOptions.DontRequireReceiver);
            }
        }       
    }
}
