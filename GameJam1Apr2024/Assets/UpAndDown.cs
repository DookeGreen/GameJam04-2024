using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float movementRange = 1f;
    public float runs = 5f;

    private bool movingUp = true;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (movingUp)
        {
            rectTransform.anchoredPosition += Vector2.up * movementSpeed * Time.deltaTime;
            if (rectTransform.anchoredPosition.y >= movementRange)
            {
                movingUp = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition -= Vector2.up * movementSpeed * Time.deltaTime;
            if (rectTransform.anchoredPosition.y <= -movementRange)
            {
                movingUp = true;
            }
        }
    }
}
