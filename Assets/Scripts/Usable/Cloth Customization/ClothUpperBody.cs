using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClothUpperBody : ICloth 
{
    public override void AssignClothRenderer()
    {
        skinRenderer = SimpleClotheCustomizer.Instance.upperBodySkinRenderer;
    }

    public override void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.upperBody = clothType;
        base.ChangeCloth();

    }

 
}
    

