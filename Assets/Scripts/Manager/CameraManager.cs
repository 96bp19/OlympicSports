using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerfollowCamPrefab, javalineFollowCamPrefab , PlayerCustomizationCamPrefab;

     private CinemachineVirtualCamera PlayerFollowingCam;
     private CinemachineVirtualCamera JavalineFollowingCam;
     private CinemachineVirtualCamera PlayerCustomizationCam;
     Vector3 playerOldPos;

    private void Start()
    {
        PlayerFollowingCam = Instantiate(playerfollowCamPrefab);
        JavalineFollowingCam = Instantiate(javalineFollowCamPrefab);
        PlayerCustomizationCam = Instantiate(PlayerCustomizationCamPrefab);
        FollowPlayer();
      //  UseCharacterCustomization(true);
    }

    private static CameraManager _Instance;
    public static CameraManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<CameraManager>();
               
            }
            return _Instance;
        }
    }

    public void FollowPlayer()
    {
        PlayerFollowingCam.Follow = GameManager.PlayerInstance.transform;
        PlayerFollowingCam.Priority = 10;
        JavalineFollowingCam.Priority = 1;
    }

    public void FollowJavaline(Transform target)
    {
        JavalineFollowingCam.Follow = target;
        JavalineFollowingCam.LookAt = target;
        PlayerFollowingCam.Priority = 1;
        JavalineFollowingCam.Priority = 10;
    }

    public void UseCharacterCustomization(bool val)
    {

        if (val)
        {
            playerOldPos = GameManager.PlayerInstance.transform.position;
            GameManager.PlayerInstance.transform.position = new Vector3(500, 500, 500);
           
        }
        else
        {
            if (playerOldPos.z !=0)
            {
                GameManager.PlayerInstance.transform.position = playerOldPos;

            }
        }

        PlayerCustomizationCam.LookAt = GameManager.PlayerInstance.transform;
        PlayerCustomizationCam.Follow = GameManager.PlayerInstance.transform;
        PlayerCustomizationCam.Priority = val ? 100 : 1;

      
    }

   



    
}
