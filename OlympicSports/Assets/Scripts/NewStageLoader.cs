using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageLoader : MonoBehaviour
{
    public GameObject[] SportsGames;

    [HideInInspector]
    public  int levelLoadIndexMax;
    private void Awake()
    {
        levelLoadIndexMax = SportsGames.Length;
    }

    private void Start()
    {
      
        Vector3 spawnPos = new Vector3(0, 0, 20);
        LoadNextSport(spawnPos);
    }

    public void LoadNextSport(Vector3 spawnPos)
    {
        int currentIndex = SaveManager.Instance.getLastLoadedLevelIndex();
        Debug.Log("level load index : " + currentIndex);
        

        if (currentIndex < SportsGames.Length)
        {
            GameObject obj = Instantiate(SportsGames[currentIndex], spawnPos, Quaternion.identity);
            Debug.Log("spawned obj pos : " + spawnPos);

        }
        else
            Debug.Log("Sports Type not found");

    }
}
