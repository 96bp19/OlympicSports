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
                currentPos += ( new Vector3(0, 0, sportLength.transform.localScale.z)  + Vector3.forward *(20-lengthCount));
                

            }
        }

        GameObject obj;
        if (finalObjectToSpawn)
        {
            obj = Instantiate(finalObjectToSpawn);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = currentPos;
            currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * 60);
        }

        obj = Instantiate(celebrationPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = currentPos;
        currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * 10);
    }
}

[System.Serializable]
public struct SportGame
{
    public LengthChanger SportPrefab;
    public bool lengthChangeable;
}
