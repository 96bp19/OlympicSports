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

    protected Vector3 rendererStartPos = new Vector3(0, 0.1f, 0), rendererEndPos = new Vector3(0,0.11f, 0);
    protected LineRenderer lineRenderer;

    

    protected virtual void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        
    }
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
        //Debug.log("trigger");
        if (other.CompareTag("Player"))
        {
            if (inputReceiveCount == 0)
            {
                //Debug.log("foul animation due to no input on " + other.name);

                PlayFoulAnimation();
                player.StopMoving(true);
            }
           
            inputListiningAllowed = false;
            player = null;
            GameManager.UIManager_Instance.EnableHoldMeter(false);
            ParticlePlayer.Instance.ResetImplosionExplostion();
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
        //Debug.log("accuracy : " + accuracy);
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
            //Debug.log("wont check for input anymore");
        }
    }

    protected void EnableLineRenderer(Vector3 pos1, Vector3 pos2)
    {
        lineRenderer.enabled = true;

        pos1.z = Mathf.Max(transform.position.z, pos1.z);
        pos2.z = Mathf.Min(transform.position.z + transform.localScale.z, pos2.z);
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);

        
    }

    protected void AddScorebasedOnAccuracy(float accuracy)
    {
        if (accuracy <0.4)
        {
            GameManager.UIManager_Instance.AddScore(1);
        }
        else if (accuracy <0.75)
        {
            GameManager.UIManager_Instance.AddScore(2);
        }
        else
        {
            GameManager.UIManager_Instance.AddScore(4);
           
        }
    }
}
