using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetA : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("SendKey", "a");
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
