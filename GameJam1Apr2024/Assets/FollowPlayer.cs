using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float zoomSpeed = 5f; // Adjust the speed of the zoom transition

    private float targetZoom;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize; // Start with the current orthographic size
    }

    void Update()
    {
        // Set the target orthographic size based on player movement
        if (!player.GetComponent<PlayerMovement>().canMove)
        {
            targetZoom = 1500f;
        }
        else
        {
            targetZoom = 3000f;
        }

        // Smoothly interpolate towards the target orthographic size
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);

        // Update camera position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 500f, -10f);
    }
}
