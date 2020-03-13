using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClotheCustomizer : MonoBehaviour
{
    public ClothInformation clothInfo;
    [SerializeField] private ClothInformation defaultClothInfo;
    public SkinnedMeshRenderer upperBodySkinRenderer, lowerBodySkinRenderer, FeetSkinRenderer;

    private static SimpleClotheCustomizer _Instance;
    public static SimpleClotheCustomizer Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameManager.PlayerInstance.GetComponent<SimpleClotheCustomizer>();
            }
            return _Instance;
        }
    }

    private void Start()
    {
        
        CheckForClothData();
    }

    void CheckForClothData()
    {
        if (clothInfo.feet == null)
        {
            clothInfo.feet = defaultClothInfo.feet;
        }

        if (clothInfo.upperBody == null)
        {
            clothInfo.upperBody = defaultClothInfo.upperBody;
        }

        if (clothInfo.lowerBody == null)
        {
            clothInfo.lowerBody = defaultClothInfo.lowerBody;
        }

        LoadClothing();
    }

    public void LoadClothing()
    {
        clothInfo.feet.ChangeCloth(FeetSkinRenderer);
        clothInfo.upperBody.ChangeCloth(upperBodySkinRenderer);
        clothInfo.lowerBody.ChangeCloth(lowerBodySkinRenderer);

    }



}
