using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetD : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("SendKey", "d");
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
