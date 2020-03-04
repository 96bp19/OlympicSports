using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCalculator : MonoBehaviour
{
    private static TimeCalculator _Instance;
    public static TimeCalculator Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<TimeCalculator>();
                if (_Instance == null)
                {
                    _Instance = new GameObject("TimeCalculator").AddComponent<TimeCalculator>();
                    
                }
            }
            return _Instance;
        }
    }

    private float currentTime = 0;
    private bool StartCounting = false;
    public float textdisappeartime = 3f;

    public void StartTimeCount()
    {
        currentTime = 0;
        StartCounting = true;
        GameManager.UIManager_Instance.EnableTimeText(true);
    }

    public void StopTimeCount()
    {
        StartCounting = false;
        Invoke("DisableTimeCountText",textdisappeartime);

    }

    public void DisableTimeCountText()
    {
        GameManager.UIManager_Instance.EnableTimeText(false);

    }

    private void Update()
    {
        if (StartCounting)
        {
            currentTime += Time.deltaTime;
            GameManager.UIManager_Instance.UpdateTimeText(currentTime);
        }
    }



}
