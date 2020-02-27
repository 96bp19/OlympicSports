﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Slider HoldMeter;
    [SerializeField] private Text ScoreText;

    private int currentScore;
    private void Awake()
    {
        if (HoldMeter)
        {
            EnableHoldMeter(false);
        }
    }
    public void EnableHoldMeter(bool value)
    {
        if (HoldMeter)
        {
            HoldMeter.gameObject.SetActive(value);
            if (value == false)
            {
                UpdateHoldMeterVal(0);
            }
           
        }
        else
        {
            Debug.LogError("javalin slider is not set in inspector , please set it");
        }
    }

    public void UpdateHoldMeterVal(float value)
    {
        HoldMeter.value = value;
    }

    public void AddScore(int value)
    {
        currentScore += value;
        ScoreText.text = currentScore.ToString();
    }

}
