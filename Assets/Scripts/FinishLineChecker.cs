using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineChecker : MonoBehaviour
{

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                
                player.ResetPlayerSpeed();
                player.GetComponent<AnimationController>().SlowDownRunSpeed();

                // get next sport type by increasing index
                int nextlevel = SaveManager.Instance.getLastLoadedLevelIndex() + 1;
                nextlevel %= GameManager.StageLoaderInstance.levelLoadIndexMax;
                SaveManager.Instance.SaveLastLevelData(nextlevel);

                // load next level
//                Debug.Log("my current pos : " + transform.position);
//                Debug.Log(" next load pos : " +( transform.position + Vector3.forward * 20));
                GameManager.StageLoaderInstance.LoadNextSport();
                
            }
        }
    }

   
}


