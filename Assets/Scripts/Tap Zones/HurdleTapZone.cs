using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class HurdleTapZone : JumpTapZone
{

    [SerializeField] private GameObject hurdleBarPrefab;
    float Playeraccuracy;

    protected void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
        float zLength = transform.lossyScale.z;
        Instantiate(hurdleBarPrefab, transform.position + new Vector3(0, 0, 1f + zLength), Quaternion.identity).transform.SetParent(transform);
    }

    public  void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        CalculateInputReceiveCount();
        accuracy = 1 -CalculatePlayerInputAccuracyWithRespectToDistance(false);
        rendererStartPos = new Vector3(0, 0, player.transform.position.z);
        rendererEndPos = new Vector3(0, 0.1f, 0.4f + player.transform.position.z);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
        PlayAnimation();

    }


    public  void PlayAnimation()
    {
        animController.HurdleJump();
        player.SetDefaultGravityMultiplier();
        //Invoke("JumpAfterDelay", 0.02f);
        //Invoke("JumpAfterDelay", 0.1f);
        Jump();
        player.AddSpeed(accuracy * 1.5f);
        
    }

    void JumpAfterDelay()
    {
        Jump();
       
    }
}
