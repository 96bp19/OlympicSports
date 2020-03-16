using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClothCustomization/ClothData")]
public class ClotheData : ScriptableObject
{
  
    public Material usedMaterial;
    public Mesh mesh;
    public Sprite ClothSprite;
    public bool itemUnlocked;
   
    public void ChangeCloth( SkinnedMeshRenderer usedSkinMeshRenderer)
    {
        usedSkinMeshRenderer.sharedMesh = mesh;
        usedSkinMeshRenderer.GetComponent<Renderer>().sharedMaterial = usedMaterial;
    }
 
}

[CreateAssetMenu(menuName = "ClothCustomization/ClothInformation")]
public class ClothInformation : ScriptableObject
{
    public ClotheData upperBody;
    public ClotheData lowerBody;
    public ClotheData feet;
}


