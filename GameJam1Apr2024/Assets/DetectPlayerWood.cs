using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerWood : MonoBehaviour
{
    [SerializeField] private GameObject PressE;
    [SerializeField] private GameObject Game;
    [SerializeField] private string NecessaryEquippedItem;
    public WoodCutting ScriptName;
    private GameObject spawnedObject;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered");
        if(col.CompareTag("Player"))
        {
            Vector3 spawnPosition = col.transform.position + new Vector3(0f, 750f, 0f);

            spawnedObject = Instantiate(PressE, spawnPosition, Quaternion.identity, col.gameObject.transform);
            spawnedObject.GetComponent<OnPressE>().Game = Game;
            spawnedObject.GetComponent<OnPressE>().Player = col.gameObject;
            spawnedObject.GetComponent<OnPressE>().NecessaryEquippedItem = NecessaryEquippedItem;
            Debug.Log("Player Entered");
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(spawnedObject);
        }
    }
}
