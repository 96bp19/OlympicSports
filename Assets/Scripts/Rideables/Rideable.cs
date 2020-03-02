using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARideable : MonoBehaviour
{
    public Animator anim;
    public float ridingHeight;

    
    public abstract void PlayPlayerRideAnimation(AnimationController playeranimController,bool value);
    
}
