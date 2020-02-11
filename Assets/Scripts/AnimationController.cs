using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            SetGroundedState(true); 
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            SetGroundedState(false);
        }
    }

    
    public void SlowDownRunSpeed()
    {
        Debug.Log("Animation reset");
        anim.SetFloat("AnimationSpeeed", 1);
    }

    public void IncreaseAnimationSpeed()
    {
        float newSpeed = anim.GetFloat("AnimationSpeeed") + 0.05f;
        anim.SetFloat("AnimationSpeeed", newSpeed);
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
}
