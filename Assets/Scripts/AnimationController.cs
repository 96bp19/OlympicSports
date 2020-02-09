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

    }

    public void LongJump()
    {

    }

    public void HurdleJump()
    {
        anim.SetTrigger("HurdleJump");
    }

    public void JavalineThrow()
    {

    }

    void SetGroundedState(bool grounded)
    {
        anim.SetBool("IsGrounded", grounded);
    }

    
}
