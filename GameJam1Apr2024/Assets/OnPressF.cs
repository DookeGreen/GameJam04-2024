using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressF : MonoBehaviour
{
    public DetectPlayerCooking FirePlace;
    public float WoodFuelValue;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && (transform.parent.GetComponent<Inventory>().EquippedItem == "Wood") && (transform.parent.GetComponent<Inventory>().woodQuantity > 0))
        {
            transform.parent.GetComponent<Inventory>().woodQuantity -= 1;
            FirePlace.currentFuel += WoodFuelValue;
        }
    }
}
