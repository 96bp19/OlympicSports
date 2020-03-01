using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public abstract class ATapZone : MonoBehaviour
{
   
    protected bool inputListiningAllowed;   
    protected float accuracy;
    protected Player player;
    [HideInInspector]
    public AnimationController animController;
  //  protected  bool inputReceived = false;

    
    [SerializeField] protected int noOfInputAlowed;

    protected int inputReceiveCount =0;

    virtual protected void OnTriggerEnter(Collider other)
    {
        // input will be registered here onwards
      
        if (other.gameObject.CompareTag("Player"))
        {
           
            player = other.GetComponent<Player>();
            animController = player.GetComponent<AnimationController>();
            inputListiningAllowed = true;
           
        }
    }

    virtual protected void OnTriggerExit(Collider other)
    {
        // input will not be registered here onwards
        Debug.Log("trigger");
        if (other.CompareTag("Player"))
        {
            if (inputReceiveCount == 0)
            {
                Debug.Log("foul animation due to no input on " + other.name);

                PlayFoulAnimation();
                player.StopMoving();
            }
           
            inputListiningAllowed = false;
            player = null;
            GameManager.UIManager_Instance.EnableHoldMeter(false);
        }

    }

    // modified accuracy means that player input will be perfect at the middle of tap zone and start and end will have 0% accuracy
    // unmodified means accuracy starts from start and linearly increase to end of the tap zone,  i.e accuracy in middle will be 50%
    public virtual float  CalculatePlayerInputAccuracyWithRespectToDistance(bool useModifiedAccuracy)
    {
        float zScale = transform.localScale.z;
        float currentPlayerPosZ = player.transform.position.z;
        float extentz = transform.position.z + zScale;

        float accuracy =  1 -Mathf.Abs( extentz - currentPlayerPosZ) / zScale;
        accuracy = Mathf.Clamp(accuracy, 0f, 1f);
        if (useModifiedAccuracy)
        {
            if (accuracy <0.5f)
            {
                accuracy = accuracy / 0.5f;
            }
            else
            {
                accuracy = (1 - accuracy) / 0.5f;
            }

        }
        Debug.Log("accuracy : " + accuracy);
        return accuracy;
        
    }

    virtual protected void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton();
    }

    protected void CalculateInputReceiveCount()
    {
        if (noOfInputAlowed == ++inputReceiveCount)
        {
            inputListiningAllowed = false;
            Debug.Log("wont check for input anymore");
        }
    }

}
