using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMax(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
    public void SetValue(float num)
    {
        slider.value = num;
    }
}
