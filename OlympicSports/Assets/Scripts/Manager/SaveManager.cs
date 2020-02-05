using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    string saveData = "aiuxaibdajdu";

    private static SaveManager saveManager;
    public static  SaveManager Instance
    {
        get
        {
            if (saveManager == null)
            {
                saveManager = FindObjectOfType<SaveManager>();
            }
            return saveManager;
        }
    }

    public void Save( SaveData data)
    {
        SaveLastLevelData(data.sportType);
    }

    public void SaveLastLevelData(int sportIndex)
    {
        string saveName = saveData + "sportType";
        PlayerPrefs.SetInt(saveName, sportIndex);
    }

    public int getLastLoadedLevelIndex()
    {
        string saveName = saveData + "sportType";
        return PlayerPrefs.GetInt(saveName, 0);
    }

    public struct SaveData
    {
        public int moneyEarned;
        public int sportType;
    }
}
