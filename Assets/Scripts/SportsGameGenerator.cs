using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsGameGenerator : MonoBehaviour
{
    [SerializeField] private SportGame[] sportsPrefab;

    // this is the object that needs to be spawned at the end of running
    // eg: high jump prefab , long jump prefab, javalin throw prefab
    //if value is null it wont be spawned
    [SerializeField] private GameObject finalObjectToSpawn;

    // this prefab will be loaded at the end of every sports to show that game has finished
    [SerializeField] private GameObject celebrationPrefab;

    [SerializeField] private int noOfSportsPrefabsToSpawn =10;

    [SerializeField] private GameObject groundPrefab;

    private void Start()
    {
        GeneratePrefabs();
    }

    public void GeneratePrefabs()
    {
        // length changer is a script that is used to change the scale of the game object , it is attached to
        // LengthChanger SportLength = Instantiate(sportsPrefab[0].SportPrefab);

        int noOfObjectsToSpawn = noOfSportsPrefabsToSpawn / sportsPrefab.Length;
        Vector3 currentPos = Vector3.forward * 15;

        LengthChanger sportLength;

        float ReducedLength = 3;
        float lengthCount = 0;
        float maxlength = (float)noOfObjectsToSpawn * sportsPrefab.Length;
        for (int i = 0; i < noOfObjectsToSpawn; i++)
        {
            for (int j = 0; j < sportsPrefab.Length; j++)
            {
                sportLength = Instantiate(sportsPrefab[j].SportPrefab);
                if (sportsPrefab[j].lengthChangeable)
                {
                    ReducedLength =  ((maxlength- lengthCount) / maxlength)*6;
                    sportLength.SetLength(ReducedLength);
                    lengthCount++;

                }

                sportLength.transform.SetParent(transform);
                sportLength.transform.localPosition = currentPos;
                float distanceTonextplatform = sportsPrefab.Length * (noOfObjectsToSpawn +1) - lengthCount;
                distanceTonextplatform = Mathf.Clamp(distanceTonextplatform,1, 15);
                currentPos += ( new Vector3(0, 0, sportLength.transform.localScale.z)  + Vector3.forward *distanceTonextplatform);
                

            }
        }

        GameObject obj;
        if (finalObjectToSpawn)
        {
            obj = Instantiate(finalObjectToSpawn);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = currentPos;
            currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * sportsPrefab[sportsPrefab.Length-1].celebrationZoneDistance);
        }

        obj = Instantiate(celebrationPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = currentPos;
        currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * 20);

        Debug.Log("current level length is : " + currentPos.z);
        Transform groundTrans = Instantiate(groundPrefab, transform).transform;
        groundTrans.SetParent(transform);
        Vector3 localpos = Vector3.zero;
        localpos.y = transform.localPosition.y-1f;
        groundTrans.localPosition = localpos;
        groundTrans.localScale = new Vector3(3, 1, currentPos.z);

        // spawn pos for next platform
        Vector3 spawnPos = transform.position + new Vector3(0, 0, currentPos.z);
        GameManager.StageLoaderInstance.SetSpawnPos(spawnPos);
    }
}

[System.Serializable]
public struct SportGame
{
    public LengthChanger SportPrefab;
    public bool lengthChangeable;
    public float celebrationZoneDistance;
}
