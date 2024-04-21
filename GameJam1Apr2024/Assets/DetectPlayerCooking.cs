using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCooking : MonoBehaviour
{
    [SerializeField] private GameObject PressE;
    [SerializeField] private GameObject PressF;
    [SerializeField] private GameObject FuelBar;
    [SerializeField] private GameObject Game;
    [SerializeField] private string NecessaryEquippedItem;
    [Range(0f, 100f)]
    [SerializeField] private float WoodFuelValue;
    [Range(0f, 100f)]
    [SerializeField] private float MaxFuel;
    [Range(0f, 10f)]
    [SerializeField] private float FuelDegen;
    public float currentFuel;
    public Cooking ScriptName;
    private GameObject spawnedObject;
    private GameObject spawnedObject1;
    private bool destroyedF = false;
    void Start()
    {
        currentFuel = MaxFuel;
    }
    void Update()
    {
        FuelBar.transform.localScale = new Vector3(50f, 1000* currentFuel/MaxFuel, 1f);
        if(currentFuel <= 0f)
        {
            this.tag = "Untagged";
        }
        else if(currentFuel > MaxFuel)
        {
            currentFuel = MaxFuel;
        }
        else
        {
            this.tag = "HeatSource";
            currentFuel -= (Time.deltaTime * FuelDegen);
        }
        if(destroyedF)
        {
            GameObject hit = GameObject.FindWithTag("Player");
            destroyedF = false;
            Vector3 spawnPosition1 = hit.transform.position + new Vector3(-125f, 750f, 0f);
            spawnedObject1 = Instantiate(PressF, spawnPosition1, Quaternion.identity, hit.gameObject.transform);
            spawnedObject1.GetComponent<OnPressF>().FirePlace = this;
            spawnedObject1.GetComponent<OnPressF>().WoodFuelValue = WoodFuelValue;
        }
        if(spawnedObject != null && spawnedObject1 != null)
        {
            if(!spawnedObject.GetComponent<OnPressE>().done)
            {
                destroyedF = true;
                Destroy(spawnedObject1);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered");
        if(col.CompareTag("Player"))
        {
            Vector3 spawnPosition = col.transform.position + new Vector3(125f, 750f, 0f);
            Vector3 spawnPosition1 = col.transform.position + new Vector3(-125f, 750f, 0f);

            spawnedObject = Instantiate(PressE, spawnPosition, Quaternion.identity, col.gameObject.transform);
            spawnedObject.GetComponent<OnPressE>().Game = Game;
            spawnedObject.GetComponent<OnPressE>().Player = col.gameObject;
            spawnedObject.GetComponent<OnPressE>().NecessaryEquippedItem = NecessaryEquippedItem;
            Debug.Log("Player Entered");
            spawnedObject1 = Instantiate(PressF, spawnPosition1, Quaternion.identity, col.gameObject.transform);
            spawnedObject1.GetComponent<OnPressF>().FirePlace = this;
            spawnedObject1.GetComponent<OnPressF>().WoodFuelValue = WoodFuelValue;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(spawnedObject);
            Destroy(spawnedObject1);
            destroyedF = false;
        }
    }
}
