using System.Collections;
using UnityEngine;
using System;


public static class MonobehaviourExtension
{
    public static void RunFunctionAfter(this MonoBehaviour behaviour, Action delegatefunction, float time,ref IEnumerator caller ,bool stopPreviousCall  = true)
    {
        if (stopPreviousCall && caller != null)
        {
            behaviour.StopCoroutine(caller);
        }
        caller = ExecuteAfterTime(delegatefunction, time , caller);
        behaviour.StartCoroutine(caller);
        
    }

    private static IEnumerator ExecuteAfterTime(Action delegatefunction, float delay , IEnumerator caller)
    {
        yield return new WaitForSeconds(delay);
        delegatefunction();
        caller = null;
    }

    public static void CancleFunctionExecution(this MonoBehaviour behaviour, ref IEnumerator stopper)
    {
        if (stopper != null)
        {
            behaviour.StopCoroutine(stopper);
            stopper = null;

        }
      
    }

   
       
        
        
    

}


