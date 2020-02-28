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
            Debug.Log("Player current gravity : " + player.getCurrentGravity());
            return Mathf.Sqrt(Mathf.Abs(2 * player.getCurrentGravity()* jumpHeight));
        }
    }
  
    public void Jump(float newJumpheight =0)
    {
        if (newJumpheight == 0)
        {
            player.getRigidbody().velocity = Vector3.up * jumpvel;

        }
        else
        {
            float originalJumpheight = jumpHeight;
            jumpHeight = newJumpheight;
            player.getRigidbody().velocity = Vector3.up * jumpvel;
            jumpHeight = originalJumpheight;

        }
    }

    
}
