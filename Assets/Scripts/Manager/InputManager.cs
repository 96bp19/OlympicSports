using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float InputBuffer =0.3f;
    private bool InputEnabled = false;
    private Inputs myInputs , defaultInputs;

    public delegate void OnInputRegistered(Inputs inputData);
    public OnInputRegistered InputListeners;

    private float currentinputTime;

    private void Awake()
    {
        defaultInputs = new Inputs(false,false);
    }

    void ClearInputBuffer()
    {
        currentinputTime = -1;
    }

    public void EnableInput(bool value = true)
    {
        Debug.Log("input enabled : " + value);
        InputEnabled = value;
        if (!InputEnabled )
        {
            ClearInputBuffer();
        }
    }

    public Inputs getInputData()
    {
        return myInputs;
    }
    

    private void Update()
    {
        
        if (InputEnabled)
        {
            UpdateInputs();

        }
        else
        {
            myInputs = defaultInputs;
        }
    }

    void UpdateInputs()
    {

        if (myInputs.screenTouched == false)
        {
            myInputs.screenTouched = Input.GetMouseButtonDown(0);
            myInputs.screenHold = myInputs.screenTouched;


        }
        if (Input.GetMouseButtonUp(0))
        {
            myInputs.screenHold = false;
            currentinputTime = InputBuffer;
        
        
        }
        if (myInputs.screenHold == false)
        {
            currentinputTime -= Time.deltaTime;

        }
        if (currentinputTime <=0 && myInputs.screenTouched)
        {
            myInputs.screenTouched = false;
            //EnableInput(false);
        }
        
        
        if (myInputs.screenTouched || myInputs.screenHold)
        {
            Debug.Log("screen touched : " + myInputs.screenTouched);
            InputListeners?.Invoke(myInputs);
            

        }
       
        
    }


}

public struct Inputs
{
    public bool screenTouched;
    public bool screenHold;

    public Inputs(bool screenTouched, bool screenHold)
    {
        this.screenTouched = screenTouched;
        this.screenHold = screenHold;
    }
}
