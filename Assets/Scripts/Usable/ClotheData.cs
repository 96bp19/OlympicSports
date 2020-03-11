﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClothCustomization/ClothData")]
public class ClotheData : ScriptableObject
{
    public Material usedMaterial;
    public Mesh mesh;
    public SkinnedMeshRenderer usedSkinMeshRenderer;

    public void ChangeCloth()
    {
        usedSkinMeshRenderer.sharedMesh = mesh;
        usedSkinMeshRenderer.GetComponent<Renderer>().sharedMaterial = usedMaterial;
    }
 
}

[CreateAssetMenu(menuName = "ClothCustomization/ClothInformation")]
public class ClothInformation : ScriptableObject
{
    public ClotheData Head;
    public ClotheData upperBody;
    public ClotheData lowerBody;
    public ClotheData feet;
}
