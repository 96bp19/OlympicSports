using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private InputManager InputManagerPrefab;
    public static InputManager InputManagerInstance;

    [SerializeField] private Player PlayerPrefab;
    public static Player PlayerInstance;

    private void Awake()
    {
        BeginGame();
    }

    private void Update()
    {
        
    }

    void BeginGame()
    {
        InputManagerInstance = Instantiate(InputManagerPrefab) as InputManager;
        PlayerInstance = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity) as Player;
        

    }

    void RestartGame()
    {

    }


}
