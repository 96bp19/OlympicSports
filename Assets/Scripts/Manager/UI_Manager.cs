using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Slider HoldMeter;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text JavalineMeterTravel;
    [SerializeField] private Text Timetext;
    [SerializeField] private Text MeterTraveledbyPlayer;

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

    public void SetJavalineMeterTravel(float distanceCovered)
    {
        
        if (!JavalineMeterTravel.gameObject.activeInHierarchy)
        {
            JavalineMeterTravel.gameObject.SetActive(true);
        }
        JavalineMeterTravel.text = distanceCovered.ToString("f2");
    }

    public void DisableUpdatingJavalineThrow()
    {
        Debug.Log("disable updating called");
        System.Action function = () => DisableJavalineThrowText();
        this.RunFunctionAfter(function, 2);
    }

    private void DisableJavalineThrowText()
    {
        JavalineMeterTravel.gameObject.SetActive(false);
    }

    public void EnableTimeText(bool value)
    {
        Timetext.gameObject.SetActive(value);
        
    }

    public void UpdateTimeText(float value)
    {
        Timetext.text = value.ToString("f2") + " s";
    }

    public void StartUpdatigMeterTravel(bool value ,float distance)
    {
        if (!MeterTraveledbyPlayer.gameObject.activeInHierarchy && value)
        {
            MeterTraveledbyPlayer.gameObject.SetActive(true);
        }

        if (value)
        {
            MeterTraveledbyPlayer.text = distance.ToString("f2") + " m";
        }
        if (value == false)
        {
            Invoke("StopUpdatingMeterTravel", 3f);
        }


    }

    void StopUpdatingMeterTravel()
    {
        MeterTraveledbyPlayer.gameObject.SetActive(false);
    }



}
