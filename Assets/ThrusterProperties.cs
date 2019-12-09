using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterProperties : MonoBehaviour
{
    //for now thrusters will have no mass, may change in future

    GameObject centre;
    GameObject ship; 
    float forceMagnitude = 10;
    Vector3 radius;
    float torque;
    float theta;
    Vector3[] data = new Vector3[2];
    Vector3 fakeTorque;
    void Start()
    {
        centre = GameObject.FindWithTag("Centre");
        ship = GameObject.FindWithTag("Ship");
        Vector3 force = Vector3.right * forceMagnitude;
        radius = transform.position - centre.transform.position;
        Vector3 axis = new Vector3();
        axis.Set(0, 0, 1);
        theta = Vector3.SignedAngle(radius, force, axis);
        torque = radius.magnitude * force.magnitude * Mathf.Sin(theta * Mathf.Deg2Rad);
        fakeTorque.Set(torque, 0, 0);
        data[0] = fakeTorque;
        data[1] = force;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ship.SendMessage("ForceApplied", data, SendMessageOptions.DontRequireReceiver);
        }
    }
}
