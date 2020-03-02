using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private GameObject swimmingSplash;
    [SerializeField] private GameObject runningDust;
    [SerializeField] private GameObject landingImpact;

    private static ParticlePlayer _Instance;
    public static ParticlePlayer Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<ParticlePlayer>();
            }
            return _Instance;
        }
    }

    [Header("Bone Sockets")]
    [SerializeField] private Transform leftlegSocket;
    [SerializeField] private Transform rightlegSocket;
    [SerializeField] private Transform leftHandSocket;
    [SerializeField] private Transform rightHandSocket;

    public void PlaySwimmingSplash(int val )
    {
        // val = 0 is left hand
        // val = 1 is right hand
        if (val ==0)
        {
            Instantiate(swimmingSplash,leftHandSocket.position, Quaternion.identity).transform.SetParent(null);

        }
        else
        Instantiate(swimmingSplash, rightHandSocket.position, Quaternion.identity).transform.SetParent(null);
        
    }

    public void PlayRunningDust(int val)
    {
        //        val = 0 is left leg
        //        val = 1 is right leg

        if (val == 0)
        {
            Instantiate(runningDust, leftlegSocket.position, Quaternion.identity).transform.SetParent(null);

        }
        else
            Instantiate(runningDust, rightlegSocket.position, Quaternion.identity).transform.SetParent(null);
    }
    
}
