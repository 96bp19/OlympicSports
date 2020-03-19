using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothFeet : ACloth
{
    public override void AssignClothRenderer()
    {
        skinRenderer = SimpleClotheCustomizer.Instance.FeetSkinRenderer;
    }

    public override void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.feet = clothType;
        base.ChangeCloth();

    }
}
