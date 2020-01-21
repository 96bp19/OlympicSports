using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Slider javalineThrowSlider;
    private bool UpdateJavalinmeterValue;

    private void Awake()
    {
        if (javalineThrowSlider)
        {
            EnableJavalineMeter(false);
        }
    }
    public void EnableJavalineMeter(bool value)
    {
        if (javalineThrowSlider)
        {
            javalineThrowSlider.gameObject.SetActive(value);
            UpdateJavalinmeterValue = value;
        }
        else
        {
            Debug.LogError("javalin slider is not set in inspector , please set it");
        }
    }

    public void UpdateJavalinMeter(float value)
    {
        javalineThrowSlider.value = value;
    }

}
