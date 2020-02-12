using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityChanger : StateMachineBehaviour
{
    [SerializeField] private float gravityMultiplier;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        GameManager.PlayerInstance.setNewGravityMutiplier(gravityMultiplier);
    }
}
