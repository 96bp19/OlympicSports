using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class JavalineThrowZone : ATapZone
{
    [SerializeField] private Transform javalineObjectPrefab;

    private Vector3 javalinThrowStartpos, JavalinThrowEndPos;
    Transform javaline;

    bool currentlyholdingJavaline = false;
    float Zextent;

    private void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenHoldStart;
        MobileInputManager.Instance.ScreenHoldListener += OnScreenHold;
        MobileInputManager.Instance.ScreenHoldFinishListener += OnScreenHoldFinish;
        Zextent = transform.localScale.z + transform.position.z;
    }


    public  void OnScreenHoldStart()
    {
        if (!inputListiningAllowed) return;
     
        javaline = Instantiate(javalineObjectPrefab, player.transform.position, Quaternion.identity);
        player.AttachToJavalineSocket(javaline);
        javaline.localScale = Vector3.one;
        animController.StartJavalineHold();
        GameManager.UIManager_Instance.EnableHoldMeter(true);
        javalinThrowStartpos = player.transform.position;
        currentlyholdingJavaline = true;
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(false);
        rendererStartPos.z = player.transform.position.z;
        ParticlePlayer.Instance.PlayImplosion();
       



    }

    public void OnScreenHold()
    {
        if (!inputListiningAllowed) return;
        
         GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance(false) - accuracy);
        rendererEndPos.z = player.transform.position.z;
        rendererEndPos.z = Mathf.Min(rendererEndPos.z, Zextent-2f);
        EnableLineRenderer(rendererStartPos, rendererEndPos);

    }

    public void OnScreenHoldFinish()
    {
        
        if (!inputListiningAllowed) return;
        CalculateInputReceiveCount();
        
        currentlyholdingJavaline = false;
        player.ResetPlayerSpeed();
        rendererEndPos.z = player.transform.position.z;
        rendererEndPos.z = Mathf.Min(rendererEndPos.z, Zextent-2f);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
        ParticlePlayer.Instance.PlayExplosion();


        // javaline throw animation
        PlayJavalineThrowAnimation(CalculatePlayerInputAccuracyWithRespectToDistance(false)-accuracy);


    }


    void ThrowJavaline(float accuracy)
    {
        if (!player)
        {
            RemoveJavaline();
            PlayFoulAnimation();
            GameManager.PlayerInstance.StopMoving();
            return;
        }
        float angleToThrowAt = calculateRandomAngleBasedOnAccuracy(accuracy);
        Vector3 launchVel = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angleToThrowAt), Mathf.Cos(Mathf.Deg2Rad * angleToThrowAt)) * 32f;
        javaline.SetParent(null);
        Rigidbody javaline_rb = javaline.GetComponent<Rigidbody>();
        javaline_rb.useGravity = true;
        javaline_rb.velocity = launchVel;
        javaline.GetComponent<Javaline>().ThrowJavaline();
        javaline.GetComponent<Javaline>().SetjavalineStartPos(transform.position + new Vector3(0, 0, transform.localScale.z));
        //Debug.log("thrown with the angle of : " + angleToThrowAt);

    }

   

    float calculateRandomAngleBasedOnAccuracy(float accuracy)
    {
        float randomAngle = 0;

        //Debug.log("throw accuracy was : " + accuracy);
        

         if (accuracy <0.5f)
        {
            //fair
            randomAngle = Random.Range(15, 25);
            
        }
        else if (accuracy <0.8f)
        {
            // good
            randomAngle = Random.Range(33, 38);
            
        }
        else
        {
            randomAngle =  Random.Range(42, 50); 
        }
        return randomAngle;
    }


    bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

    IEnumerator enumerator;
    void PlayJavalineThrowAnimation(float accuracy)
    {
        animController.JavalineThrow();
        System.Action javalinethrowAction = () => ThrowJavaline(accuracy);
        AnimationEventHandler.Instance.setNewEventFunction(javalinethrowAction);
        
    }

    void RemoveJavaline()
    {
        if (javaline)
        {
            Destroy(javaline.gameObject);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
      
        if (other.CompareTag("Player") && currentlyholdingJavaline)
        {
          
            RemoveJavaline();
            PlayFoulAnimation();
            player.StopMoving();
        }
        base.OnTriggerExit(other);
    }

    protected override void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton(true);
    }


   
}
