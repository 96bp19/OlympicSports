using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsGameGenerator : MonoBehaviour
{
    
    public bool useStartingObj;
    [ConditionalHide("useStartingObj",true)]
    public GameObject StartingObjectToSpawn;
    [ConditionalHide("useStartingObj",true)]
    public float distanceFromStartingObjToOther = 20;

    public bool useFinalObj;
    [ConditionalHide("useFinalObj",true)]
    public GameObject finalObjectToSpawn;

    [ConditionalHide("useFinalObj", true)]
    public float finalObjectDistance =15f;

    public bool useTimeCounter;
    [ConditionalHide("useTimeCounter", true)]
    public GameObject TimeEnablerPrefab;
  

    // this prefab will be loaded at the end of every sports to show that game has finished

    [SerializeField] private int noOfSportsPrefabsToSpawn =10;
    [SerializeField] private float gameStartingDistance = 15;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject celebrationPrefab;
    [SerializeField] private SportGame[] sportsPrefab;
    [SerializeField] private float minimumDistanceBetweenPlatforms=5f;
    [SerializeField] private float maxDistanceBetweenPlatforms = 15f;
    [SerializeField] private GameObject FlagPrefab;

    private void Start()
    {
        GeneratePrefabs();
    }

    public void GeneratePrefabs()
    {
        // length changer is a script that is used to change the scale of the game object , it is attached to
        // LengthChanger SportLength = Instantiate(sportsPrefab[0].SportPrefab);

        GenerateFlag();
        int noOfObjectsToSpawn = noOfSportsPrefabsToSpawn / sportsPrefab.Length;

        Vector3 currentPos = Vector3.forward * gameStartingDistance;
        if (useStartingObj)
        {
            Transform objtrans = Instantiate(StartingObjectToSpawn, currentPos, Quaternion.identity).transform;
            objtrans.SetParent(transform);
            objtrans.localPosition = currentPos;
            currentPos.z += distanceFromStartingObjToOther;
        }

        LengthChanger sportLength;

        float ReducedLength = 3;
        float lengthCount = 0;
        float maxlength = (float)noOfObjectsToSpawn * sportsPrefab.Length;
        for (int i = 0; i < noOfObjectsToSpawn; i++)
        {
            if (i == 0)
            {
                InstantiateTimeEnabler(currentPos);
            }

            for (int j = 0; j < sportsPrefab.Length; j++)
            {
                sportLength = Instantiate(sportsPrefab[j].SportPrefab);
                if (sportsPrefab[j].lengthChangeable)
                {
                    ReducedLength = ((maxlength - lengthCount) / maxlength) * 6;
                    sportLength.SetLength(ReducedLength);
                    lengthCount++;

                }

                sportLength.transform.SetParent(transform);
                sportLength.transform.localPosition = currentPos;
                float distanceTonextplatform = sportsPrefab.Length * (noOfObjectsToSpawn + 1) - lengthCount;
                distanceTonextplatform = Mathf.Clamp(distanceTonextplatform, minimumDistanceBetweenPlatforms, maxDistanceBetweenPlatforms);
                currentPos += (new Vector3(0, 0, sportLength.transform.localScale.z) + Vector3.forward * distanceTonextplatform);


            }
            if (i == noOfObjectsToSpawn - 1)
            {
                SetTimeEnablerScale(currentPos);
            }
        }

        GameObject obj;
        bool celebrationZoneDistanceChanged = false;
        if (useFinalObj)
        {
            obj = Instantiate(finalObjectToSpawn);
            obj.transform.SetParent(transform);
            currentPos.z += finalObjectDistance;
            obj.transform.localPosition = currentPos;
            celebrationZoneDistanceChanged = true;
            currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * sportsPrefab[sportsPrefab.Length - 1].celebrationZoneDistance);

        }
        if (!celebrationZoneDistanceChanged)
        {
            currentPos += (Vector3.forward * sportsPrefab[sportsPrefab.Length - 1].celebrationZoneDistance);

        }
        obj = Instantiate(celebrationPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = currentPos;
        currentPos += (new Vector3(0, 0, obj.transform.localScale.z) + Vector3.forward * 20);


        Transform groundTrans = Instantiate(groundPrefab, transform).transform;
        groundTrans.SetParent(transform);
        Vector3 localpos = Vector3.zero;
        localpos.y = transform.localPosition.y;
        groundTrans.localEulerAngles = new Vector3(0, 180, 0);
        groundTrans.localPosition = localpos;
        groundTrans.localScale = new Vector3(3, 1, currentPos.z);

        // spawn pos for next platform
        Vector3 spawnPos = transform.position + new Vector3(0, 0, currentPos.z);
        GameManager.StageLoaderInstance.SetSpawnPos(spawnPos);
    }

    private void GenerateFlag()
    {
        if (FlagPrefab)
        {
            Transform flagTransform = Instantiate(FlagPrefab).transform;
            flagTransform.SetParent(transform);
            flagTransform.localPosition = new Vector3(1f, -0.1f, 9f);

        }
    }

    private GameObject timeEnabler;
    void InstantiateTimeEnabler(Vector3 SpawnPos)
    {
        if (useTimeCounter)
        {
            timeEnabler = Instantiate(TimeEnablerPrefab);
            timeEnabler.transform.SetParent(transform);
            timeEnabler.transform.localPosition = SpawnPos;
        }
    }

    void SetTimeEnablerScale(Vector3 currentPos)
    {
        if (useTimeCounter && timeEnabler)
        {
            Vector3 scale = timeEnabler.transform.localScale;
            scale.z = currentPos.z - timeEnabler.transform.localPosition.z;
            timeEnabler.transform.localScale = scale;

        }
    }
}

[System.Serializable]
public struct SportGame
{
    public LengthChanger SportPrefab;
    public bool lengthChangeable;
    public float celebrationZoneDistance;
}
