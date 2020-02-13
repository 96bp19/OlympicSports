using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavalineThrowZone : ATapZone
{
    [SerializeField] private Transform javalineObjectPrefab;

    private Vector3 javalinThrowStartpos, JavalinThrowEndPos;
    private float startAccuracy = 0;


    Transform javaline;
    public override void DoInputAction(float accuracy)
    {
        javaline = Instantiate(javalineObjectPrefab, player.transform.position, Quaternion.identity);
        player.AttachToJavalineSocket(javaline);
        animController.StartJavalineHold();
        javalineHoldStart = true;
        GameManager.UIManager_Instance.EnableHoldMeter(true);
        javalinThrowStartpos = player.transform.position;
        startAccuracy = accuracy;
        
    }

    bool javalineHoldStart;
    private void Update()
    {
        if (javalineHoldStart)
        {
            if (player)
            {
                GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance()- startAccuracy+0.1f);
                if (GameManager.InputManagerInstance.getInputData().screenHold == false)
                {
                        javalineHoldStart = false;
                
                        player.ResetPlayerSpeed();
                        float newAccuracy = CalculatePlayerInputAccuracyWithRespectToDistance() - startAccuracy;

                    // javaline throw animation
                        PlayJavalineThrowAnimation(newAccuracy);
                       
                }
            }
            else
            {
                Debug.Log("foul");
                javalineHoldStart = false;
            }
        }
    }

    void ThrowJavaline(float accuracy)
    {
        if (!player)
        {
            RemoveJavaline();
            animController.PlayFoulAnimaiton();
            GameManager.PlayerInstance.StopMoving();
            return;
        }
        float angleToThrowAt = calculateRandomAngleBasedOnAccuracy(accuracy);
        float throwPower = Random.Range(55, 60);
        Vector3 launchVel = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angleToThrowAt), Mathf.Cos(Mathf.Deg2Rad * angleToThrowAt)) * throwPower;
        Debug.Log("launch vel : " + launchVel);


        javaline.SetParent(null);
        Rigidbody javaline_rb = javaline.GetComponent<Rigidbody>();
        javaline_rb.velocity = launchVel;
        javaline.GetComponent<Javaline>().setTarget(player.transform);
        Debug.Log("thrown with the angle of : " + angleToThrowAt);

    }

    float calculateRandomAngleBasedOnAccuracy(float accuracy)
    {
        float randomAngle = 0;

        if (accuracy <0.25)
        {
            randomAngle = Random.Range(75, 90);
        }

        else if (accuracy <0.5f)
        {
            //fair
            randomAngle = RandomBool() ? Random.Range(25, 35) : Random.Range(60, 75); 
            
        }
        else if (accuracy <0.8f)
        {
            // good
            randomAngle = RandomBool() ? Random.Range(35, 42) : Random.Range(48, 60); 
            
        }
        else
        {
            randomAngle =  Random.Range(42, 48); 
        }
        return randomAngle;
    }


    bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

    public override void PlayAnimation()
    {
       
    }

    IEnumerator enumerator;
    void PlayJavalineThrowAnimation(float accuracy)
    {
        animController.JavalineThrow();
        System.Action javalinethrowAction = () => ThrowJavaline(accuracy);
        this.RunFunctionAfter(javalinethrowAction, 0.8f, ref enumerator);
        

    }

    void RemoveJavaline()
    {
        if (javaline)
        {
            Destroy(javaline);
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && javalineHoldStart)
        {
            RemoveJavaline();           
            player.StopMoving();
        }
        base.OnTriggerExit(other);
    }

    protected override void PlayFoulAnimation()
    {
        animController.PlayFoulAnimaiton(true);
    }
}
