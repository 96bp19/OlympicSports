using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycling : ARideable
{
    public override void PlayPlayerRideAnimation(AnimationController playeranimController, bool value)
    {
       
        playeranimController.StartCycling(value);
        if (value)
        {
            anim.SetTrigger("RideStart");
        }
    }
}
