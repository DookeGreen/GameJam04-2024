using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRectTransformSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform parentRectTransform; // Reference to the parent RectTransform
    [SerializeField] private GameObject objectToSpawnPrefab; // Prefab of the object to spawn
    [SerializeField] private GameObject pointObj;
    private RectTransform bar;

    private RectTransform spawnedObject;

    void Start()
    {
        bar = objectToSpawnPrefab.GetComponent<RectTransform>();
        
        Spawn();
    }

    public void Spawn()
    {
        // Check if there's already a spawned object in the scene
        if (spawnedObject != null)
        {
            // Destroy the previously spawned object
            Destroy(spawnedObject.gameObject);
        }

        // Ensure that both the parentRectTransform and objectToSpawnPrefab are assigned
        if (parentRectTransform == null || bar == null)
        {
            Debug.LogError("Please assign both the parentRectTransform and objectToSpawnPrefab!");
            return;
        }

        Vector2 parentSize = parentRectTransform.rect.size;

        // Calculate random position within the parent RectTransform
        float randomX = Random.Range(-parentSize.x / 2f, parentSize.x / 2f);
        Vector3 randomPosition = new Vector3(randomX, 0f, 0f); // Use randomY for Y position

        // Spawn the object at the random position
        spawnedObject = Instantiate(bar, parentRectTransform);
        spawnedObject.localPosition = randomPosition;
        spawnedObject.localScale = new Vector3(0.33f / pointObj.GetComponent<WoodCutting>().runs, 1f, 1f);
    }

}