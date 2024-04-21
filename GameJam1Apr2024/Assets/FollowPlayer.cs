using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float targetZoom = 3000f;

    private void Start()
    {
        // Start the zooming coroutine
        StartCoroutine(ZoomCoroutine());
    }

    private IEnumerator ZoomCoroutine()
    {
        // Get the current orthographic size of the camera
        float currentZoom = GetComponent<Camera>().orthographicSize;

        // Loop until the camera reaches the target zoom
        while (Mathf.Abs(currentZoom - targetZoom) > 0.01f)
        {
            // Smoothly interpolate between the current zoom and the target zoom
            currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * zoomSpeed);

            // Update the orthographic size of the camera
            GetComponent<Camera>().orthographicSize = currentZoom;

            yield return null;
        }
    }

    private void LateUpdate()
    {
        // Follow the player with the camera
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 500f, -10f);
        }
    }
}
