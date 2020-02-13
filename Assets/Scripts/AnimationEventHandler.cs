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
}
