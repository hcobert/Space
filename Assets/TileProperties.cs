using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour
{
    public float tileMass = 100;
    private float momentInertia;
    GameObject ship; 
    void Start()
    {        
        ship = GameObject.FindWithTag("Ship");

        //Send inertia data
        float distance = (ship.transform.position - gameObject.transform.position).magnitude;
        momentInertia = tileMass * distance * distance;
        ship.SendMessage("SumInertia", momentInertia, SendMessageOptions.DontRequireReceiver);

        //Send centre of mass data
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float[] massXYArray = new float[] {tileMass, xPos, yPos};
        ship.SendMessage("CentreOfMass", massXYArray, SendMessageOptions.DontRequireReceiver);
    }

}
