using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineChecker : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AnimationController>().PlayWinAnimation(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                
                player.ResetPlayerSpeed();
                // get next sport type by increasing index
                int nextlevel = SaveManager.Instance.getLastLoadedLevelIndex() + 1;
                nextlevel %= GameManager.StageLoaderInstance.levelLoadIndexMax;
                SaveManager.Instance.SaveLastLevelData(nextlevel);
                other.GetComponent<AnimationController>().PlayWinAnimation(false);

                GameManager.StageLoaderInstance.LoadNextSport();
               
                
            }
        }

        
    }

   
}


