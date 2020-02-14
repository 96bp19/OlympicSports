using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private InputManager InputManagerPrefab;
    public static InputManager InputManagerInstance;

    [SerializeField] private Player PlayerPrefab;
    public static Player PlayerInstance;

    [SerializeField] private UI_Manager UImanagerprefab;
    public static UI_Manager UIManager_Instance;

    [SerializeField] private NewStageLoader StageLoaderPrefab;
    public static NewStageLoader StageLoaderInstance;

    [SerializeField] private SaveManager saveManagerPrefab;

    private void Awake()
    {
        BeginGame();
    }

    void BeginGame()
    {
        GameObject allmanagers = new GameObject("All Managers");
        transform.SetParent(allmanagers.transform);
        InputManagerInstance = Instantiate(InputManagerPrefab) as InputManager;
        InputManagerInstance.transform.SetParent(allmanagers.transform);

        PlayerInstance = Instantiate(PlayerPrefab, new Vector3(0,2,5), Quaternion.identity) as Player;
      

        UIManager_Instance = Instantiate(UImanagerprefab) as UI_Manager;
        UIManager_Instance.transform.SetParent(allmanagers.transform);
        StageLoaderInstance = Instantiate(StageLoaderPrefab) as NewStageLoader;
        Instantiate(saveManagerPrefab).transform.SetParent(allmanagers.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Debug.Log("minus");
            Time.timeScale -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log("plus");
            Time.timeScale += 0.1f;
        }
    }



}
