using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJumpTapZone : JumpTapZone
{

    [SerializeField] private GameObject hurdleBarPrefab;
    float Playeraccuracy;

    protected override void Start()
    {
        base.Start();
        float zLength = transform.lossyScale.z;
        Instantiate(hurdleBarPrefab, transform.position + new Vector3(0, 0, 0.15f + zLength), Quaternion.identity).transform.SetParent(null);
    }

    public override void DoInputAction(float accuracy)
    {
        this.Playeraccuracy = accuracy;
        PlayAnimation();
 
    }


    public override void PlayAnimation()
    {
        animController.HurdleJump();
        player.SetDefaultGravityMultiplier();
        Invoke("JumpAfterDelay", 0.02f);
        
    }

    void JumpAfterDelay()
    {

        base.DoInputAction(Playeraccuracy);

    }
}
