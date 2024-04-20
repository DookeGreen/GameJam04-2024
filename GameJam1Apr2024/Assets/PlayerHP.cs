using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float Hunger;
    public float Heat;

    [Range(0f, 100f)]
    [SerializeField] private float HungerThreshold;
    [Range(0f, 1f)]
    [SerializeField] private float HungerDegenRate;
    [Range(0f, 100f)]
    [SerializeField] private float ColdThreshold;
    [Range(0f, 1f)]
    [SerializeField] private float HeatDegenRate;
    [Range(0f, 1f)]
    [SerializeField] private float HeatSourceMaxDistance;
    [SerializeField] LayerMask HeatSourceLayer;

    void Update()
    {
        Hunger -= (Time.deltaTime * HungerDegenRate);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, HeatSourceMaxDistance, Vector2.zero, HeatSourceLayer);
        if(hit)
        {
            Heat -= (Time.deltaTime * HeatDegenRate);
        }
    }

    void Eat(float HungerValue)
    {
        Hunger += HungerValue;
    }
    
    void Warmth(Transform HeatSourceLocation)
    {
        Heat += Vector3.Distance(transform.position, HeatSourceLocation.position);
    }
}
