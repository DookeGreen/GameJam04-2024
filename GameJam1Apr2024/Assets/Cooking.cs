using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] private float GameTimer;
    [SerializeField] private Rigidbody2D rb;
    [Range(0f, 20f)]
    [SerializeField] private float MoveSpeed;
    [Range(0f, 10f)]
    [SerializeField] private float CookTime;
    [SerializeField] private GameObject TimerBar;
    [SerializeField] private GameObject CookingBar;
    private float currentTime;
    private float CurrentCookTime;
    private bool TouchingZone = false;
    public int score;
    public bool finished;
    void Start()
    {
        currentTime = GameTimer;
    }
    // Update is called once per frame
    void Update()
    {
        TimerBar.transform.localScale = new Vector3(0.5f, GameTimer/currentTime, 1f);
        CookingBar.transform.localScale = new Vector3(0.5f, CurrentCookTime/CookTime, 1f);
        if(CurrentCookTime >= CookTime)
        {
            score = 1;
            finished = true;
        }
        if(!finished)
        {
            if(TouchingZone)
            {
                if(CurrentCookTime <= CookTime)
                {
                    CurrentCookTime += Time.deltaTime;
                }
            }
            else{
                if(CurrentCookTime > 0)
                {
                    CurrentCookTime -= Time.deltaTime;
                }
            }
            if(currentTime > 0)
            {
                currentTime += Time.deltaTime;
                if(Input.GetMouseButton(0))
                {
                    rb.velocity += new Vector2(0f, MoveSpeed);
                }
            }
            else
            {
                score = 0;
                finished = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Zone"))
        {
            TouchingZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Zone"))
        {
            TouchingZone = false;
        }  
    }
}
