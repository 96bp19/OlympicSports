using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isOnGround;

   
   

    public bool IsOnGround()
    {
        return isOnGround;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (IsOnGround() == false)
            {
                SetGroundedState(true);
            }
            
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            SetGroundedState(false);
            
        }
    }
   

    public void HighJump()
    {
        anim.SetTrigger("HighJump");

    }

    public void LongJump()
    {
        anim.SetTrigger("LongJump");

    }

    public void HurdleJump()
    {
        anim.SetTrigger("HurdleJump");
    }

    public void JavalineThrow()
    {
        anim.SetTrigger("JavalinThrow");

    }

    void SetGroundedState(bool grounded)
    {
        isOnGround = grounded;
        anim.SetBool("IsGrounded", grounded);
    }

    public void UpdatePlayerSpeed()
    {
        anim.SetFloat("PlayerSpeed", GameManager.PlayerInstance.GetCurrentPlayerSpeed());
    }

    public void StartSwimming(bool value)
    {
        Debug.Log("swimming : " + value);
        if (value)
        {
            anim.SetTrigger("SwimStart");
            anim.ResetTrigger("SwimEnd");

        }

        else
        {
            anim.SetTrigger("SwimEnd");

        }
    }

    public void Swim()
    {
        Debug.Log("swim Called");
    }

   
    public void TripleJump(int tripleJumpVal)
    {
       
        anim.SetInteger("TripleJump", tripleJumpVal);
        Debug.Log("current triple jump val : " + tripleJumpVal);
    }

    public void PlayFoulAnimaiton(bool NormalFoul = false)
    {

        resetAllAnimations();
        if (NormalFoul)
        {
            anim.SetTrigger("NormalFoul");
        }
        else
        {
            anim.SetTrigger("Foul");

        }
        Binaya.MyInput.MobileInputManager.Instance.EnableInput(false);

    }

    public void resetAllAnimations()
    {
        anim.SetInteger("TripleJump", 0);
    }

    public void StartJavalineHold()
    {
        anim.SetTrigger("JavalineHoldRun");
        
    }

    public void StartHorseRiding(bool value)
    {
        anim.SetBool("StartHorseRiding", value);
    }

}
