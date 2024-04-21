using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public int score;
    public bool finished;
    [Range(0f, 10f)]
    [SerializeField] private float GameTimer;
    [Range(0f, 10f)]
    [SerializeField] private float BarDegen;
    [Range(0f, 10f)]
    [SerializeField] private float BarIncrease;
    [SerializeField] private GameObject TimerBar;

    private float currentTime;

    void Start()
    {
        currentTime = GameTimer;
    }
    void Update()
    {
        TimerBar.transform.localScale = new Vector3(1f, GameTimer/currentTime, 1f);
        if(transform.localScale.y >= 1){
            finished = true;
            score = 1;
        }
        if(!finished)
        {
            if(currentTime > 0)
            {
                currentTime += Time.deltaTime;
                if(transform.localScale.y != 0)
                {
                    transform.localScale -= new Vector3(0f, Time.deltaTime * BarDegen, 0f);

                }
                if(Input.GetMouseButtonDown(0))
                {
                    if((transform.localScale + new Vector3(0f, BarIncrease, 0f)).y > 1f)
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else
                    {
                        transform.localScale += new Vector3(0f, BarIncrease, 0f);
                    }
                }
            }
            else
            {
                finished = true;
                score = 0;
            }
        }

    }
}
