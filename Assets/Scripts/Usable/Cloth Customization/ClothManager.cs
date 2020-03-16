using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothManager : MonoBehaviour
{
    public ClothUnlocker clothUnlocker;

    private static ClothManager _Instance;
    public static ClothManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<ClothManager>();
            }
            return _Instance;
        }
    }

    public void UnlockRandomCloth()
    {
        clothUnlocker.UnlockCloth();
    }
}
