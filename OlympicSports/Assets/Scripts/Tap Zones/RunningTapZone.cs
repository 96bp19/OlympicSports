using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTapZone : ATapZone
{
    public override void DoInputAction()
    {
        player.AddSpeed(5);    
    }


}
