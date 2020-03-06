using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;
public class HighJumpTapZone : JumpTapZone
{
    [SerializeField] private GameObject highJumpPole;
    bool startCountingMeter;
    float meterTraveled;
    private void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
        Transform highjumpploleTrans = Instantiate(highJumpPole).transform;
        highjumpploleTrans.SetParent(transform);
        highjumpploleTrans.localPosition = new Vector3(0, 0, 1.5f);
    }

    public void OnScreenTap()
    {
        if (!inputListiningAllowed) return;

        CalculateInputReceiveCount();
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(true);
        
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        rendererStartPos = new Vector3(0, 0, player.transform.position.z);
        rendererEndPos = new Vector3(0, 0.1f, 0.4f + player.transform.position.z);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
        float heightForjump = calculateJumpheightBasedOnAccuracy(accuracy);
        heightForjump = Mathf.Max(heightForjump, Random.Range(2f, 3f));
        PlayAnimation();
        Jump(heightForjump);
        Invoke("startMeterCount", 0.05f);
    }

    public void PlayAnimation()
    {
        animController.HighJump();
    }

    float calculateJumpheightBasedOnAccuracy(float accuracy)
    {
        Debug.Log("accuracy : " + accuracy);
        return accuracy * jumpHeight;

    }

    private void Update()
    {
        if (!startCountingMeter) return;
        meterTraveled = Mathf.Max(GameManager.PlayerInstance.transform.position.y, meterTraveled);
        if (!GameManager.PlayerInstance.isGrounded())
        {
            GameManager.UIManager_Instance.StartUpdatigMeterTravel(true, meterTraveled);

        }
        else
        {
            GameManager.UIManager_Instance.StartUpdatigMeterTravel(false, meterTraveled);
            startCountingMeter = false;
        }

    }
    
    void startMeterCount()
    {
        startCountingMeter = true;
       
    }






}
