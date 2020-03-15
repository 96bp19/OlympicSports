using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class  ICloth : MonoBehaviour,IPointerClickHandler
{

    public ClotheData clothType;
    protected SkinnedMeshRenderer skinRenderer;
    public virtual void Start()
    {
        AssignClothRenderer();
    }

    public abstract void AssignClothRenderer();
   

    public  virtual void ChangeCloth()
    {
        clothType.ChangeCloth(skinRenderer);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeCloth();
    }
}
