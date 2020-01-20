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

    private void Start()
    {
       
        GameManager.InputManagerInstance.InputListeners += OnInputReceived;
    }

    void OnInputReceived(Inputs inp)
    {
        Debug.Log("Input received");
        if (inputListiningAllowed)
        {
            Debug.Log("input registered on " + name);
            accuracy = PlayerInputAccuracyCalculatorWithRespectToDistance();
            DoInputAction(accuracy);
            inputListiningAllowed = false;
            triggercheckAllowed = false;
          
        }
        else
        {
            Debug.Log("input not registered on " + name);
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
        }
    }

    float  PlayerInputAccuracyCalculatorWithRespectToDistance()
    {
        float zScale = transform.localScale.z;
        float currentPlayerPosZ = player.transform.position.z;
        float extentz = transform.position.z + zScale;

        float accuracy =  1 -Mathf.Abs(currentPlayerPosZ - extentz) / zScale;
        accuracy = Mathf.Clamp(accuracy, 0.1f, 1f);

        return accuracy;
        
    }


}
