using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerfollowCamPrefab, javalineFollowCamPrefab;

     private CinemachineVirtualCamera PlayerFollowingCam;
     private CinemachineVirtualCamera JavalineFollowingCam;

    private void Start()
    {
        PlayerFollowingCam = Instantiate(playerfollowCamPrefab);
        JavalineFollowingCam = Instantiate(javalineFollowCamPrefab);
        FollowPlayer();
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

   



    
}
