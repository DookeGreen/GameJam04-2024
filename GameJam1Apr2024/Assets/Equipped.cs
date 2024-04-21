using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipped : MonoBehaviour
{
    public bool equipped;

    void Update()
    {
        if(equipped)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
