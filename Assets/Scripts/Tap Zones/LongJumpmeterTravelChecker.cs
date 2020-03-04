using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJumpmeterTravelChecker : MonoBehaviour
{
    [SerializeField] private float scaleZ =15;
    bool allwedUpdating = false;
    float startZ;
    float distanceTraveled;
    
    private void Start()
    {
        //scaleZ = transform.localScale.z;
        startZ = transform.position.z;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allwedUpdating = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!allwedUpdating) return;

        if (other.CompareTag("Player"))
        {
            distanceTraveled = (GameManager.PlayerInstance.transform.position.z - startZ) * 15 / scaleZ;
            distanceTraveled = Mathf.Max(distanceTraveled, 0);
            GameManager.UIManager_Instance.StartUpdatigMeterTravel(true, distanceTraveled);
            if (GameManager.PlayerInstance.isGrounded())
            {
                allwedUpdating = false;
                GameManager.UIManager_Instance.StartUpdatigMeterTravel(false, 5);
            }
        }
    }
}
