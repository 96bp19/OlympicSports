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

    virtual protected void Start()
    {
        MobileInputManager.Instance.ScreenTapListener += OnScreenTap;
        MobileInputManager.Instance.ScreenHoldListener += OnScreenHold;
        MobileInputManager.Instance.ScreenHoldFinishListener += OnScreenHoldFinish;
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenHoldStart;
       
    }

    public abstract void PlayAnimation();
    public virtual void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        CalculateInputReceiveCount();
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance();
    }

    public virtual void OnScreenHold()
    {
        if (!inputListiningAllowed) return;
               
    }

    public virtual void OnScreenHoldFinish()
    {
        if (!inputListiningAllowed) return;


        CalculateInputReceiveCount();
        inputListiningAllowed = false;
    }

    public virtual void OnScreenHoldStart()
    {
        if (!inputListiningAllowed) return;
        
    }


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
        if (other.CompareTag("Player"))
        {
            if (inputReceiveCount == 0)
            {
                Debug.Log("foul animation due to no input");
                PlayFoulAnimation();
                player.StopMoving();
            }
           
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

    virtual protected void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton();
    }

    protected void CalculateInputReceiveCount()
    {
        if (noOfInputAlowed == ++inputReceiveCount)
        {
            inputListiningAllowed = false;
        }
    }

}
