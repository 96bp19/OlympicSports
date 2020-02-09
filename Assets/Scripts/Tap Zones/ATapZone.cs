using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATapZone : MonoBehaviour
{
   
    private bool inputListiningAllowed;
    private bool triggercheckAllowed = true;
    private float accuracy;
    protected Player player;




    public abstract void DoInputAction(float accuracy);
    public abstract void PlayAnimation(AnimationController animController);
   


    private void Start()
    {
       
        GameManager.InputManagerInstance.InputListeners += OnInputReceived;
    }

    void OnInputReceived(Inputs inp)
    {
      
        if (inputListiningAllowed)
        {
            accuracy = CalculatePlayerInputAccuracyWithRespectToDistance();
            DoInputAction(accuracy);
      
            PlayAnimation(player.GetComponent<AnimationController>());
            inputListiningAllowed = false;
            triggercheckAllowed = false;
          
        }
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        // input will be registered here onwards
        if (!triggercheckAllowed)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
           
            player = other.GetComponent<Player>();
            inputListiningAllowed = true;
            GameManager.InputManagerInstance.EnableInput(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // input will not be registered here onwards
        if (other.CompareTag("Player"))
        {
            GameManager.InputManagerInstance.EnableInput(false);
            inputListiningAllowed = false;
            player = null;
            GameManager.UIManager_Instance.EnableHoldMeter(false);
        }
    }

    public float  CalculatePlayerInputAccuracyWithRespectToDistance()
    {
        float zScale = transform.localScale.z;
        float currentPlayerPosZ = player.transform.position.z;
        float extentz = transform.position.z + zScale;

        float accuracy =  1 -Mathf.Abs((currentPlayerPosZ-1) - extentz) / zScale;
        accuracy = Mathf.Clamp(accuracy, 0f, 1f);

        return accuracy;
        
    }


}
