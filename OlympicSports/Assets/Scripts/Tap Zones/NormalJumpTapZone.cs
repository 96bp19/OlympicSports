using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJumpTapZone : JumpTapZone
{
   
    public override void DoInputAction()
    {
        player.SetDefaultGravityMultiplier();
        base.DoInputAction();
    }

   

  
}
