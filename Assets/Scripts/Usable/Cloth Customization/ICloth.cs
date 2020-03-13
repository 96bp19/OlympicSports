using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  ICloth : MonoBehaviour
{

    public ClotheData clothType;
    SkinnedMeshRenderer skinRenderer;
    public virtual void Start()
    {
        AssignClothRenderer();
    }

    void AssignClothRenderer()
    {
        skinRenderer = SimpleClotheCustomizer.Instance.FeetSkinRenderer;
    }

    public  virtual void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.feet = clothType;
        clothType.ChangeCloth(skinRenderer);
    }
}
