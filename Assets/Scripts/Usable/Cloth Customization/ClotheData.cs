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
    public delegate void OnClothUnlocked();
    public OnClothUnlocked ClothUnlockedListeners;


    public void ChangeCloth( SkinnedMeshRenderer usedSkinMeshRenderer)
    {
        if (itemUnlocked)
        {
            usedSkinMeshRenderer.sharedMesh = mesh;
            usedSkinMeshRenderer.GetComponent<Renderer>().sharedMaterial = usedMaterial;

        }
    }

    public void UnlockItem()
    {
        itemUnlocked = true;
        ClothUnlockedListeners?.Invoke();
    }

   
    
}

[CreateAssetMenu(menuName = "ClothCustomization/ClothInformation")]
public class ClothInformation : ScriptableObject
{
    public ClotheData upperBody;
    public ClotheData lowerBody;
    public ClotheData feet;
    public ClotheData Head;
}

[CreateAssetMenu(menuName = "ClothCustomization/Clothunlocker")]
public class ClothUnlocker :ScriptableObject
{
    public List<ClotheData> clotheDatas;
    


    public void UnlockCloth()
    {
        int length = clotheDatas.Count;
        int randomIndex = Random.Range(0, length);
        clotheDatas[randomIndex].UnlockItem();
        clotheDatas.RemoveAt(randomIndex);
        
    }
}


