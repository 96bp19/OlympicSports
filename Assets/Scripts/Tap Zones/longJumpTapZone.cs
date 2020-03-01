﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class longJumpTapZone : JumpTapZone
{
    private bool screenHolding = false;
   

    [SerializeField] private GameObject SandZonePrefab;

   
    protected  void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenHoldStart;
        MobileInputManager.Instance.ScreenHoldListener += OnScreenHold;
        MobileInputManager.Instance.ScreenHoldFinishListener += OnScreenHoldFinish;
        
        Transform sandtrans = Instantiate(SandZonePrefab, transform.position + new Vector3(0, 0.15f, transform.lossyScale.z + 15/2+3f), Quaternion.identity).transform;
        sandtrans.SetParent(transform);
    }

    public  void OnScreenHoldStart()
    {
        if (!inputListiningAllowed) return;
        Debug.Log("long jump hold start");
        

        screenHolding = true;
        player.setNewGravityMutiplier(3);
        player.ResetPlayerSpeed();
        GameManager.UIManager_Instance.EnableHoldMeter(true);
    }

    public void OnScreenHold()
    {
        if (!inputListiningAllowed) return;
        
        UpdatePlayerSpeed();
        Debug.Log("screen holding : " + screenHolding);
        GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance(false));

    }

    public void OnScreenHoldFinish()
    {
        if (!inputListiningAllowed) return;
        screenHolding = false;        
        PlayAnimation();
        Jump();
        CalculateInputReceiveCount();
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(false);
    }


    public  void PlayAnimation()
    {
        animController.LongJump();

    }

    void UpdatePlayerSpeed()
    {
        player.AddSpeed(Time.fixedDeltaTime*2);
        animController.UpdatePlayerSpeed();
    }

    private void Update()
    {
        if (screenHolding && !inputListiningAllowed)
        {
            screenHolding = false;
            PlayFoulAnimation();
            GameManager.PlayerInstance.StopMoving();

        }
    }

    protected override void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton(true);
    }
}
