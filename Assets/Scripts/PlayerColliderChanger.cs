using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderChanger : MonoBehaviour
{
    [SerializeField] private AnimationColliderHeightChecker colliderHeigthChecker;
    private CapsuleCollider col;
    private float defaultColliderHeight;
    private float capsuleHeight;
    private bool useDefaultColliderHeight = false;
    Vector3 capsuleheightOffset;

   

    private void Start()
    {
        col = GetComponent<CapsuleCollider>();
      
        defaultColliderHeight = colliderHeigthChecker.getDefaultCapsuleHeight();
        
    }

    private void Update()
    {
        colliderHeigthChecker.getColliderInfoWithRespectToAnimation(out CapsuleColliderInfo info, 0.5f);
        col.height = info.height;
        if (!GameManager.PlayerInstance.isGrounded())
        {
            info.center.y *= -1f;
        }
        col.center = info.center;
        col.radius = info.radius;
    }

    public void UseDefaultColliderHeight(bool value)
    {
        useDefaultColliderHeight = value;
    }


}
