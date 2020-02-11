using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageLoader : MonoBehaviour
{
    public GameObject[] SportsGames;

    [HideInInspector]
    public  int levelLoadIndexMax;

    private Vector3 newSpawnPos;

    public void SetSpawnPos(Vector3 newpos)
    {
        newSpawnPos = newpos;
    }


    private void Awake()
    {
        levelLoadIndexMax = SportsGames.Length;
    }

    private void Start()
    {

        SetSpawnPos(Vector3.zero);
        LoadNextSport();
    }

    public void LoadNextSport()
    {
        int currentIndex = SaveManager.Instance.getLastLoadedLevelIndex();
        Debug.Log("level load index : " + currentIndex);
        

        if (currentIndex < SportsGames.Length)
        {
            GameObject obj = Instantiate(SportsGames[currentIndex], newSpawnPos, Quaternion.identity);


        }
        else
            Debug.Log("Sports Type not found");

    }
}
