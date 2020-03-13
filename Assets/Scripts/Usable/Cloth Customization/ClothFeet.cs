using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothFeet : ICloth
{
    public override void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.feet = clothType;
        base.ChangeCloth();

    }
}
