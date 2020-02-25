using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longJumpTapZone : JumpTapZone
{
    private bool screenHolding = false;
    private float startAccuracy = 0;

    [SerializeField] private GameObject SandZonePrefab;

    public override void OnScreenTap()
    {
        // blank function intended
    }

    public override void OnScreenHoldStart()
    {
        if (!inputListiningAllowed) return;
        Debug.Log("long jump hold start");
        base.OnScreenHoldStart();

        screenHolding = true;
        player.setNewGravityMutiplier(5);
        player.ResetPlayerSpeed();
        GameManager.UIManager_Instance.EnableHoldMeter(true);
    }

    public override void OnScreenHold()
    {
        if (!inputListiningAllowed) return;
        base.OnScreenHold();
        UpdatePlayerSpeed();
        Debug.Log("screen holding : " + screenHolding);
        GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance());

    }

    public override void OnScreenHoldFinish()
    {
        if (!inputListiningAllowed) return;
        screenHolding = false;
        base.OnScreenHoldFinish();
        PlayAnimation();
        Jump();
    }

    protected override void Start()
    {
        base.Start();
        Transform sandtrans = Instantiate(SandZonePrefab, transform.position + new Vector3(0, 0.5f, transform.lossyScale.z + 15/2+3f), Quaternion.identity).transform;
        sandtrans.SetParent(transform);
    }

    public override void PlayAnimation()
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
            player.StopMoving();

        }
    }

    protected override void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton(true);
    }
}
