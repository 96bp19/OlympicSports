using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class longJumpTapZone : JumpTapZone
{
    private bool screenHolding = false;
   

    [SerializeField] private GameObject SandZonePrefab;


    float Zextent;
    protected  void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenHoldStart;
        MobileInputManager.Instance.ScreenHoldListener += OnScreenHold;
        MobileInputManager.Instance.ScreenHoldFinishListener += OnScreenHoldFinish;
        Zextent = transform.localScale.z + transform.position.z;

        Transform sandtrans = Instantiate(SandZonePrefab, transform.position + new Vector3(0, 0.15f, transform.lossyScale.z+3f), Quaternion.identity).transform;
        sandtrans.SetParent(transform);
    }

    public  void OnScreenHoldStart()
    {
        //Debug.log("input listening allowed : " + inputListiningAllowed);
        if (!inputListiningAllowed) return;
        //Debug.log("long jump hold start");
        

        screenHolding = true;
        player.setNewGravityMutiplier(3);
        rendererStartPos.z = player.transform.position.z;
        
        // player.ResetPlayerSpeed();
        GameManager.UIManager_Instance.EnableHoldMeter(true);
        ParticlePlayer.Instance.PlayImplosion();
    }

    public void OnScreenHold()
    {
        if (!inputListiningAllowed) return;
        
        UpdatePlayerSpeed();
        //Debug.log("screen holding : " + screenHolding);
        GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance(false));
        rendererEndPos.z = player.transform.position.z;
        rendererEndPos.z = Mathf.Min(rendererEndPos.z, Zextent-0.1f);
        EnableLineRenderer(rendererStartPos, rendererEndPos);

    }

    public void OnScreenHoldFinish()
    {
        if (!inputListiningAllowed) return;
        screenHolding = false;        
        PlayAnimation();
        Jump();
        rendererEndPos.z = player.transform.position.z;
        rendererEndPos.z = Mathf.Min(rendererEndPos.z, Zextent - 0.1f);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(false);
        CalculateInputReceiveCount();
        ParticlePlayer.Instance.PlayExplosion();
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
            GameManager.PlayerInstance.StopMoving(false);
           

        }
    }

    protected override void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton(true);
    }
}
