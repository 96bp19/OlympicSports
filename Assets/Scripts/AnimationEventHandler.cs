using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEventHandler : MonoBehaviour
{

    // this is dynamic function that will be set to run 
    Action functionToRun;

    private static AnimationEventHandler _Instance;
    public static AnimationEventHandler Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<AnimationEventHandler>();
            }
            return _Instance;
        }
    }

    public delegate void OnSwimAnimationStarted( bool val);
    public OnSwimAnimationStarted SwimAnimationListeners;

    // this takes the function signature reference to use later
    public void setNewEventFunction(Action action)
    {
        functionToRun = action;
    }

    public void RunEventFunction()
    {
        Debug.Log("animation event run");
        functionToRun?.Invoke();
    }

   /// <summary>
   /// use 0 for false and 1 for true
   /// </summary>
   /// <param val="value"></param>
    public void SwimAnimationTriggered(int value)
    {
        value = Mathf.Clamp(value, 0, 1);
        if (value ==1)
        {
            SwimAnimationListeners?.Invoke(true);
        }
        else if (value ==0)
        {
            SwimAnimationListeners?.Invoke(false);

        }
      
    }

    


}
