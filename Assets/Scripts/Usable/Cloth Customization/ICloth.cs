using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button),typeof(Image))]
public abstract class  ICloth : MonoBehaviour,IPointerClickHandler
{

    public ClotheData clothType;
    [SerializeField] private Image lockedUnlockedImage;
    [SerializeField] Sprite LockedImage;
    [SerializeField] Sprite UnlockedImage;

    protected SkinnedMeshRenderer skinRenderer;
    private Image MainItemImageImage;
    private bool ItemUnlocked;


    void UnlockItem(bool value)
    {
        ItemUnlocked = value;
        ChangeBackGroundImageBasedOnItemUnlock(value);
        clothType.itemUnlocked = value;
    }

    void ChangeBackGroundImageBasedOnItemUnlock(bool value)
    {
        lockedUnlockedImage.sprite = value ? UnlockedImage : LockedImage;
    }

    public virtual void Start()
    {
        MainItemImageImage = GetComponent<Image>();
        ItemUnlocked = clothType.itemUnlocked;
        UnlockItem(ItemUnlocked);
        MainItemImageImage.sprite = clothType.ClothSprite;
        AssignClothRenderer();

    }

    public abstract void AssignClothRenderer();
   

    public  virtual void ChangeCloth()
    {
        clothType.ChangeCloth(skinRenderer);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemUnlocked)
        {
            ChangeCloth();
        }
    }
}
