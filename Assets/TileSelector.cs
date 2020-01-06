using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public GameObject ship;
    void OnMouseDown()
    {
        ship.SendMessage("TileSelected");
    }
    void OnMouseEnter()
    {
        ship.SendMessage("CantPlace",true);
    }
    void OnMouseExit()
    {
        ship.SendMessage("CantPlace",false);
    }
}
