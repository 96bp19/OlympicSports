using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth_head :ACloth
{
    public override void AssignClothRenderer()
    {
        skinRenderer = SimpleClotheCustomizer.Instance.HeadSkinRenderer;
    }

    public override void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.Head = clothType;
        base.ChangeCloth();

    }
}
