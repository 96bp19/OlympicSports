using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabFieldManager : MonoBehaviour
{
    public Transform UpperBodyTabField, LowerBodyTabField, ShoeTabField;
    public GameObject[] UpperBodyItems;
    public GameObject[] lowerBodyItems;
    public GameObject[] ShoeItems;


    private void Start()
    {
        InstantiateMultipleObject(UpperBodyItems, UpperBodyTabField);
        InstantiateMultipleObject(lowerBodyItems,LowerBodyTabField);
        InstantiateMultipleObject(ShoeItems,ShoeTabField);
    }

    void InstantiateMultipleObject(GameObject[] objToInstiantiate,Transform parent)
    {
        for (int i = 0; i < objToInstiantiate.Length; i++)
        {
            Instantiate(objToInstiantiate[i], parent);
        }
    }
}
