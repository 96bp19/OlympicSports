using UnityEngine;

public class AnimationColliderHeightChecker : MonoBehaviour
{
   [SerializeField] private Transform headTrans;
   [SerializeField] private Transform leftLegTrans;
   [SerializeField] private Transform rightLegTrans;

    [SerializeField] private Vector3 headPos;
    [SerializeField] private Vector3 leftLegPos;
    [SerializeField] private Vector3 rightlegPos;

    [SerializeField] private float capsuleHeight;
    [SerializeField] private float defaultCapusleHeight;

    

    bool useDefaultHeight = false;

    private void Start()
    {
        
        defaultCapusleHeight = checkForCapsuleHeight();
    }

    public float checkForCapsuleHeight()
    {
        headPos = headTrans.position;
        leftLegPos = leftLegTrans.position;
        rightlegPos = rightLegTrans.position;

        if (leftLegPos.y < rightlegPos.y)
        {
            capsuleHeight = headPos.y - leftLegPos.y;
        }
        else
        {
            capsuleHeight = headPos.y - rightlegPos.y;
        }
        return capsuleHeight;
    }

    public void getCapsuleCenteroffsetAndRadius(out float radius , out Vector3 centeroffset , float usedCapsuleradius)
    {
        centeroffset = Vector3.zero;
        centeroffset.y = -(defaultCapusleHeight - capsuleHeight) / 2;
        radius = Mathf.Min( Mathf.Abs(capsuleHeight) / 2, usedCapsuleradius);
       
    }
    public float getDefaultCapsuleHeight()
    {
        return defaultCapusleHeight;
    }

    public void getColliderInfoWithRespectToAnimation(out CapsuleColliderInfo info , float defaultRadius)
    {
        info.height = Mathf.Abs(checkForCapsuleHeight());
        info.center =Vector3.zero;
        info.center.y = -(defaultCapusleHeight - info.height) / 2;
        info.radius = Mathf.Min(info.height / 2, defaultRadius);
        
    }
}

public struct CapsuleColliderInfo
{
    public float height;
    public float radius;
    public Vector3 center;
}


 


