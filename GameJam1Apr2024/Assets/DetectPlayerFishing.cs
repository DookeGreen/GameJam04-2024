using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerFishing : MonoBehaviour
{
    [SerializeField] private GameObject PressE;
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject ExclamationPoint;
    [SerializeField] private string NecessaryEquippedItem;
    [Range(0f, 10f)]
    [SerializeField] private float MaxFishingTime;
    public Fishing ScriptName;
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
            spawnedObject.GetComponent<OnPressE>().timer = Random.Range(0f, MaxFishingTime);
            spawnedObject.GetComponent<OnPressE>().ExclamationPoint = ExclamationPoint;
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
