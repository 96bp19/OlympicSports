using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavalineThrowZone : ATapZone
{
    [SerializeField] private Transform javalineObjectPrefab;
    public override void DoInputAction(float accuracy)
    {
        player.ResetPlayerSpeed();
        ThrowJavaline(accuracy);
    }
    
    void ThrowJavaline(float accuracy)
    {
        float angleToThrowAt = calculateRandomAngleBasedOnAccuracy(accuracy);
        float throwPower = Random.Range(55, 60);
        Vector3 launchVel = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angleToThrowAt), Mathf.Cos(Mathf.Deg2Rad * angleToThrowAt)) * throwPower;
        Debug.Log("launch vel : " + launchVel);
        Transform javaline = Instantiate(javalineObjectPrefab, player.transform.position, Quaternion.identity);
        Rigidbody javaline_rb = javaline.GetComponent<Rigidbody>();
        javaline_rb.velocity = launchVel;
        javaline.GetComponent<Javaline>().setTarget(player.transform);
        Debug.Log("thrown with the angle of : " + angleToThrowAt);

    }

    float calculateRandomAngleBasedOnAccuracy(float accuracy)
    {
        float randomAngle = 0;
        if (accuracy <0.5f)
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
}
