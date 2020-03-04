using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private GameObject swimmingSplash;
    [SerializeField] private GameObject runningDust;
    [SerializeField] private GameObject landingImpact;
    [SerializeField] private GameObject Implosion;
    [SerializeField] private GameObject Explosion;


    private Transform swimmingLefthandParticle, swimmingRightHandParticle;
    private Transform dustLeftLegParticle, dustRightLegParticle;

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
        if (val == 0)
        {
            ReuseParticle(ref swimmingLefthandParticle, swimmingSplash, leftHandSocket);
        }
        else
            ReuseParticle(ref swimmingRightHandParticle, swimmingSplash, rightHandSocket);
        
    }

    public void PlayRunningDust(int val)
    {
        //        val = 0 is left leg
        //        val = 1 is right leg

        if (val == 0)
        {
            ReuseParticle(ref dustLeftLegParticle, runningDust, leftlegSocket);

        }
        else
            ReuseParticle(ref dustRightLegParticle, runningDust, rightlegSocket);
    }

    public void PlayImplosion()
    {
        Explosion.SetActive(false);
        Implosion.SetActive(false);
        Implosion.gameObject.SetActive(true);
    }

    public void PlayExplosion()
    {
        Explosion.SetActive(false);
        Implosion.SetActive(false);
        Explosion.gameObject.SetActive(true);
    }

    public void PlayLandingDustParticle()
    {
        landingImpact.SetActive(false);
        landingImpact.SetActive(true);
    }

    public void ReuseParticle(ref Transform particleTrans ,GameObject particlePrefab ,Transform socketTrans)
    {
        if (particleTrans == null)
        {
            particleTrans = Instantiate(particlePrefab, socketTrans.position, Quaternion.identity).transform;
            particleTrans.SetParent(null);
            particleTrans.position = socketTrans.position;
        }
        else
        {
            particleTrans.gameObject.SetActive(false);
            particleTrans.gameObject.SetActive(true);
            particleTrans.SetParent(null);
            particleTrans.position = socketTrans.position;
        }
    }

    public void ResetImplosionExplostion()
    {
        Implosion.gameObject.SetActive(false);
        Explosion.gameObject.SetActive(false);
    }
    
}
