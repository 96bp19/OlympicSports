using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedReset : StateMachineBehaviour
{
   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("AnimationSpeeed", 1);
        GameManager.PlayerInstance.ResetPlayerSpeed();
      
    }

   
}
