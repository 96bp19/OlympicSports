using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController animcontroller = other.GetComponent<AnimationController>();
            if (animcontroller)
            {
                animcontroller.StartSwimming(false);
                GameManager.PlayerInstance.ResetPlayerSpeed();
            }
        }
    }
}
