using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipForces : MonoBehaviour
{
    //moment of inertia
    float momentOfInertia;

    //total mass of ship
    float totalMass = 0;
    //total sum of mass of ship part * x position of ship part
    float totalXMass = 0;
    //total sum of mass of ship part * y position of ship part
    float totalYMass = 0;

    //x and y coordinates for centre of mass
    float xCentrePos;
    float yCentrePos;

    //vector2 position of centre of mass (constructed with above x and y)
    Vector2 centreOfMassPosition;

    //resultant force
    Vector2 relativeResultantForce;

    //angular acceleration
    float angularAcceleration;

    void Start()
    {
        relativeResultantForce.Set(0, 0);
    }

    //whenever a new ship part is added, recalculate the moment of inertia
    public void SumInertia(float inMomentInertia)
    {
        //I = Σmr^2
        momentOfInertia += inMomentInertia;
    }   
    //whenever a new ship part is added, recalculate the centre of mass
    public void CentreOfMass(float[] inArray)
    {
        totalMass += inArray[0];

        //xbar = (m1x1 + m2x2 + ...) / (m1 + m2 + ...)
        totalXMass += inArray[0] * inArray[1];
        xCentrePos = totalXMass / totalMass;

        //ybar = (m1y1 + m2y2 + ...) / (m1 + m2 + ...)
        totalYMass += inArray[0] * inArray[2];
        yCentrePos = totalYMass / totalMass;

        //move the centre of mass to the calculated position
        centreOfMassPosition.x = xCentrePos;
        centreOfMassPosition.y = yCentrePos;
        GameObject centre = GameObject.FindWithTag("Centre");
        centre.transform.position = centreOfMassPosition;
    }    

    public void ForceApplied(Force inForce)
    {
        if (inForce.GetIsAdding() == true)
        {
            //Handle torque, derive angular acceleration
            angularAcceleration += inForce.GetTorque() / momentOfInertia;

            //Add relative force vector to relative resultant force vector
            Vector2 relativeForce = inForce.GetRelativeForce();
            relativeResultantForce += relativeForce;
        }
        else
        {
            //Handle torque
            angularAcceleration -= inForce.GetTorque() / momentOfInertia;

            //Minus relative force vector from relative resultant force vector
            Vector2 relativeForce = inForce.GetRelativeForce();
            relativeResultantForce -= relativeForce;
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().angularVelocity += angularAcceleration;

        //each update, derive from relative resultant force the true vector of acceleration
        /*
        float theta = Mathf.Deg2Rad * gameObject.transform.rotation.z; //angle of rotation in radians
        float newX = (relativeResultantForce.x * Mathf.Cos(theta)) - (relativeResultantForce.y * Mathf.Sin(theta));
        float newY = (relativeResultantForce.x * Mathf.Sin(theta)) + (relativeResultantForce.y * Mathf.Cos(theta));
        Vector2 currentForce = new Vector2(newX, newY);
        */

        gameObject.GetComponent<Rigidbody2D>().mass = totalMass; 
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(relativeResultantForce);
    }
}
