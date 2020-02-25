using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderChanger : MonoBehaviour
{
    public AnimationCurve curve;
    public Vector3 colliderCenter;
    public float height;
    [Range(0f, 1f)] public float lerpTime = 0;

    public float maxHeight;

    CapsuleCollider col;
    // Update is called once per frame

   

    private void Start()
    {
        col = GetComponent<CapsuleCollider>();

    }
    void Update()
    {
        col.center = colliderCenter;
        col.height = height;

        float lerpedval = curve.Evaluate(lerpTime);

        colliderCenter.y = maxHeight/2 - lerpedval;
        col.height = lerpedval * maxHeight;

        

    }
}
