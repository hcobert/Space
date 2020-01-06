using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterSelector : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("ThrusterSelected");
    }
    void OnMouseEnter()
    {
        ship.SendMessage("CantPlace", true);
    }
    void OnMouseExit()
    {
        ship.SendMessage("CantPlace", false);
    }
}
