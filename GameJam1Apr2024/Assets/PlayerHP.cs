using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float Hunger;
    public float Heat;
    public ValueBar valueBarHeat;
    public ValueBar valueBarHunger;

    [Range(0f, 100f)]
    [SerializeField] private float HungerThreshold;
    [Range(0f, 10f)]
    [SerializeField] private float HungerDegenRate;
    [Range(0f, 100f)]
    [SerializeField] private float ColdThreshold;
    [Range(0f, 10f)]
    [SerializeField] private float HeatDegenRate;
    [Range(0f, 10f)]
    [SerializeField] private float HeatGainRate;
    [Range(0f, 10000f)]
    [SerializeField] private float HeatSourceMaxDistance;
    [SerializeField] LayerMask HeatSourceLayer;
    void Start()
    {
        valueBarHeat.SetMax(ColdThreshold);
        valueBarHunger.SetMax(HungerThreshold);
        Heat = ColdThreshold;
        Hunger = HungerThreshold;
    }
    void Update()
    {
        valueBarHeat.SetValue(Heat);
        valueBarHunger.SetValue(Hunger);
        Hunger -= (Time.deltaTime * HungerDegenRate);
        Collider2D hit = Physics2D.OverlapCircle(transform.position, HeatSourceMaxDistance, HeatSourceLayer);
        if (hit != null)
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.red);
            if (hit.CompareTag("HeatSource"))
            {
                Debug.Log("Hit Heat Source");
                Warmth(hit.transform);
            }
        }
        else
        {
            Debug.Log("Not Hit Heat Source");
            Heat -= HeatDegenRate * Time.deltaTime;
        }
    }
    void OnDrawGizmos()
    {
        DebugExtension.DrawCircle(transform.position, Vector3.back, Color.blue, HeatSourceMaxDistance);
    }
    void Eat(float HungerValue)
    {
        Hunger += HungerValue;
    }
    
    void Warmth(Transform HeatSourceLocation)
    {
        if (Heat < ColdThreshold)
        {
            if(HeatSourceMaxDistance - Vector3.Distance(transform.position, HeatSourceLocation.position) > 0)
            {
                Heat += (HeatGainRate * (HeatSourceMaxDistance - Vector3.Distance(transform.position, HeatSourceLocation.position)));
            }
            // Optionally, you might want to clamp the Heat value to prevent it from exceeding ColdThreshold
            Heat = Mathf.Min(Heat, ColdThreshold);
        }
    }
}
