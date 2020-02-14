using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingZone : MonoBehaviour
{

    Player player;

    bool swimInputAllowed;
    void OnSwimInputAllowed(bool value )
    {
        swimInputAllowed = value;
     //   Debug.Log("swimming allowed : " + value);
    }

    private void Start()
    {
        AnimationEventHandler.Instance.SwimAnimationListeners += OnSwimInputAllowed;
    }

    private void Update()
    {
        InputAction();
    }

    // action to be performed when input received
    void InputAction()
    {

        if (receiveInput == false) return; 
        
        if (player == null) player = GameManager.PlayerInstance;

        bool inputreceived = Input.GetMouseButtonDown(0);
        if (inputreceived)
        {
            if (swimInputAllowed)
            {

                player.AddSpeed(1);
                Debug.Log("nice swimming");
                swimInputAllowed = false;

            }
            else
            {
                player.ResetPlayerSpeed();
                Debug.Log("bad swim");
            }

        }
    }


    bool receiveInput =false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            receiveInput = true;
            
        }
    }

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
            receiveInput = false;
        }

    }
}
