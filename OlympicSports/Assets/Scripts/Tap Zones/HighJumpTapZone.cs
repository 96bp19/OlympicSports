using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTapZone : JumpTapZone
{
    public override void DoInputAction()
    {
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        base.DoInputAction();
       
        
    }

    
}
