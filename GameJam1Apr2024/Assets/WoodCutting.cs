using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutting : MonoBehaviour
{
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject Zone;
    [SerializeField] private GameObject Spawner;

    public float movementSpeed = 1f;
    public float movementRange = 1f;
    public float runs = 5f;

    private bool movingRight = true;
    private RectTransform rectTransform;

    public bool stopped;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Zone = GameObject.FindWithTag("Zone");
        movementSpeed += (Time.deltaTime * 0.025f);
        // Move the cutting tool back and forth
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stopped = true;
        }
        if(stopped)
        {
            Debug.Log(IsOverZone());
        }
        else if (movingRight)
        {
            rectTransform.anchoredPosition += Vector2.right * movementSpeed * Time.deltaTime;
            if (rectTransform.anchoredPosition.x >= movementRange)
            {
                movingRight = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition -= Vector2.right * movementSpeed * Time.deltaTime;
            if (rectTransform.anchoredPosition.x <= -movementRange)
            {
                movingRight = true;
            }
        }
    }
    bool IsOverZone()
    {
        Vector2 point = new Vector2(rectTransform.position.x, rectTransform.position.y);
        if(Zone.transform.GetComponent<Collider2D>().OverlapPoint(point)){
            runs += 1;
            stopped = false;
            Spawner.GetComponent<RandomRectTransformSpawner>().Spawn();
            return true;
        }
        return false;
    }
}
