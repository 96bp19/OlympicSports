using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATapZone : MonoBehaviour
{
   
    private bool inputListiningAllowed;

    protected Player player;

    public abstract void DoInputAction();

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
            DoInputAction();
          
        }
        else
        {
            Debug.Log("input not registered on " + name);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        // input will be registered here onwards
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


}
