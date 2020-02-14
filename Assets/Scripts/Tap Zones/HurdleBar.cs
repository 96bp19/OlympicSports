using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleBar : MonoBehaviour
{
    IEnumerator enumerator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController animcontroller = other.GetComponent<AnimationController>();

         
            animcontroller.PlayFoulAnimaiton();
            GameManager.PlayerInstance.StopMoving();

           // System.Action delegatefunction = () => EnableMovement();
          //  this.RunFunctionAfter(delegatefunction, 0.2f, ref enumerator);
            
        }
        
    }

    void EnableMovement()
    {
        GameManager.PlayerInstance.StartMoving(false);
  
    }
   

}
