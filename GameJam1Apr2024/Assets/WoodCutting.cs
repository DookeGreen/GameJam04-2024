using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutting : MonoBehaviour
{
    [SerializeField] GameObject Plus;
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject Zone;
    [SerializeField] private GameObject Spawner;

    public float movementSpeed = 1f;
    public float movementRange = 1f;
    public float runs = 5f;

    private bool movingRight = true;
    private RectTransform rectTransform;
    public int score;

    public bool stopped;
    public bool finished;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
         
        Zone = GameObject.FindWithTag("Zone");
        movementSpeed += (Time.deltaTime * 0.025f);
        // Move the cutting tool back and forth
        if(Input.GetMouseButtonDown(0))
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
            score += 1;
            if(score % 2 == 1)
            {
                Vector3 spawnPosition = transform.position + new Vector3(250f, 250f, 0f);
                GameObject plus = Instantiate(Plus, spawnPosition, Quaternion.identity);
            }
            stopped = false;
            Spawner.GetComponent<RandomRectTransformSpawner>().Spawn();
            return true;
        }
        finished = true;
        return false;
    }
}
