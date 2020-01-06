using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force
{
    //Characteristics
    Vector2 relativeForce;
    float torque;    
    bool isAdding;

    //Constructor
    public Force(Vector2 inRelativeForce, float inTorque, bool inIsAdding)
    {
        relativeForce = inRelativeForce;
        torque = inTorque;
        isAdding = inIsAdding;
    }

    //Setters
    public void SetRelativeForce(Vector2 inRelativeForce)
    {
        relativeForce = inRelativeForce;
    }
    public void SetTorque(float inTorque)
    {
        torque = inTorque;
    }
    public void SetIsAdding(bool inIsAdding)
    {
        isAdding = inIsAdding;
    }

    //Getters
    public Vector2 GetRelativeForce()
    {
        return relativeForce;
    }
    public float GetTorque()
    {
        return torque;
    }
    public bool GetIsAdding()
    {
        return isAdding;
    }
}

public class ThrusterProperties : MonoBehaviour
{
    //for now thrusters will have no mass, may change in future

    GameObject centre;
    GameObject ship; 

    float forceMagnitude = 10;

    Vector2 radius;

    Vector2 force;
    float torque;
    float theta;

    void Start()
    {
        //find centre of mass and ship game objects
        centre = GameObject.FindWithTag("Centre");
        ship = GameObject.FindWithTag("Ship");      
      
        //calculate the radius vector with A->B = b - a 
        radius = transform.position - centre.transform.position;

        //calculate the force vector applied by the thruster
        force = transform.right * forceMagnitude;

        //calculate the angle between the radius and force vectors
        theta = Vector2.SignedAngle(radius, force); 

        //calculate the torque applied by the thruster with T = rFsin(theta)
        torque = radius.magnitude * force.magnitude * Mathf.Sin(theta * Mathf.Deg2Rad);
    }
    void OnMouseEnter()
    {
        ship.SendMessage("CantPlace",true);   
    }
    void OnMouseExit()
    {
        ship.SendMessage("CantPlace",false);
    }
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.W))
        {
            Force sendForce = new Force(force, torque, true);
            ship.SendMessage("ForceApplied", sendForce, SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Force sendForce = new Force(force, torque, false);
            ship.SendMessage("ForceApplied", sendForce, SendMessageOptions.DontRequireReceiver);
        }
    }
}
