using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnPressF : MonoBehaviour
{
    public DetectPlayerCooking FirePlace;
    public float WoodFuelValue;
    [SerializeField] private GameObject Minus;
    public TextMeshProUGUI ErrorTXT;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && (transform.parent.GetComponent<Inventory>().EquippedItem == "Wood") && (transform.parent.GetComponent<Inventory>().woodQuantity > 0))
        {
            transform.parent.GetComponent<Inventory>().woodQuantity -= 1;
            FirePlace.currentFuel += WoodFuelValue;
            Vector3 spawnPosition = GameObject.FindWithTag("Player").transform.position + new Vector3(250f, 250f, 0f);
            GameObject minus = Instantiate(Minus, spawnPosition, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.F) && (transform.parent.GetComponent<Inventory>().EquippedItem == "Wood"))
        {
            ErrorTXT.text = "Not enough wood!";
        }
        else if(Input.GetKeyDown(KeyCode.F) && (transform.parent.GetComponent<Inventory>().woodQuantity > 0))
        {
            ErrorTXT.text = "Wrong item equipped!";
        }
    }
}
