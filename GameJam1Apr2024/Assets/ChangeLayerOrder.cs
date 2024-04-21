using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOrder : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject player;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if(player.transform.position.y > transform.position.y)
        {
            sr.sortingOrder = 5;
        }
        else
        {
            sr.sortingOrder = -1;
        }
    }
}
