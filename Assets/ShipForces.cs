using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipForces : MonoBehaviour
{
    float momentOfInertia;

    float totalMass = 0;
    float totalXMass = 0;
    float totalYMass = 0;

    float xCentrePos;
    float yCentrePos;

    Vector2 centreOfMassPosition;

    float linearAcceleration;
    Vector2 linearAccelDirection;
    float angularAcceleration;
    void Start()
    {

    }
    public void SumInertia(float inMomentInertia)
    {
        //I = Σmr^2
        momentOfInertia += inMomentInertia;
    }   
    public void CentreOfMass(float[] inArray)
    {
        totalMass += inArray[0];
        totalXMass += inArray[0] * inArray[1];
        totalYMass += inArray[0] * inArray[2];
        xCentrePos = totalXMass / totalMass;
        yCentrePos = totalYMass / totalMass;
        centreOfMassPosition.x = xCentrePos;
        centreOfMassPosition.y = yCentrePos;
        GameObject centre = GameObject.FindWithTag("Centre");
        centre.transform.position = centreOfMassPosition;
    }    

    public void ForceApplied(Vector3[] inData)
    {
        //Handle force vector(inData[1]) to find linear acceleration to apply to ship
        //Using F = ma
        linearAcceleration = inData[1].magnitude / totalMass;
        linearAccelDirection = inData[1].normalized;

        //Handle torque vector(inData[0]) and moment of inertia (momentOfInertia) to find angular acceleration to apply to ship
        //Using T = Ia
        angularAcceleration = (inData[0].x / momentOfInertia);
        
    }
    void FixedUpdate()
    {
        Debug.Log(centreOfMassPosition);
        gameObject.GetComponent<Rigidbody2D>().velocity += linearAccelDirection * linearAcceleration;
        gameObject.GetComponent<Rigidbody2D>().angularVelocity += angularAcceleration;
    }
}
