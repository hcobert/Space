using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetS : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("SendKey", "s");
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
