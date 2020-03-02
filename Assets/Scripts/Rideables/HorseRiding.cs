using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRiding : ARideable
{
    public override void PlayPlayerRideAnimation(AnimationController playeranimController , bool value)
    {
        playeranimController.StartHorseRiding(value);
    }
}
