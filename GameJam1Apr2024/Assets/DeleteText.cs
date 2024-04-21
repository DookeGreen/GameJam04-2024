using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ErrorTXT;
    private float timer;
    void Update()
    {
        if(ErrorTXT.text != "")
        {
            timer += Time.deltaTime;
            if(timer > 1f)
            {
                timer = 0f;
                ErrorTXT.text = "";
            }
        }
    }
}
