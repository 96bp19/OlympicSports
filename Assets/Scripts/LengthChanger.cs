using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthChanger : MonoBehaviour
{
   [SerializeField] private float minLength=1 , maxLength=3;
  
   
    public void SetLength(float length)
    {
        length = Mathf.Clamp(length,minLength, maxLength);
        transform.localScale = new Vector3(3, 1, length);
    }

}
