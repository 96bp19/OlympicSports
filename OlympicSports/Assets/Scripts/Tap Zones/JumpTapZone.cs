using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JumpTapZone : ATapZone
{
    [SerializeField] protected float jumpHeight;

    
    public float jumpvel
    {
        get
        {
            return Mathf.Sqrt(Mathf.Abs(2 * player.getCurrentGravity()* jumpHeight));
        }
    }
    public override void DoInputAction()
    {
       
        player.getRigidbody().velocity = Vector3.up * jumpvel;
    }
}
