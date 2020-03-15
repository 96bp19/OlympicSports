﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothLowerBody :ICloth
{
    public override void AssignClothRenderer()
    {
        skinRenderer = SimpleClotheCustomizer.Instance.lowerBodySkinRenderer;
    }

    public override void ChangeCloth()
    {
        SimpleClotheCustomizer.Instance.clothInfo.lowerBody = clothType;
        base.ChangeCloth();
       
    }


}
