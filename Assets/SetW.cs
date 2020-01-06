using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetW : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("SendKey", "w");
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
