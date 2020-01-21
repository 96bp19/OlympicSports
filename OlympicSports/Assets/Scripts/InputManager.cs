using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool InputEnabled = false;
    private Inputs myInputs , defaultInputs;

    public delegate void OnInputRegistered(Inputs inputData);
    public OnInputRegistered InputListeners;

    private void Awake()
    {
        defaultInputs = new Inputs(false,false);
    }

    public void EnableInput(bool value = true)
    {
        InputEnabled = value;
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
        myInputs.screenTouched = Input.GetMouseButtonDown(0);

        if (myInputs.screenTouched)
        {
            myInputs.screenHold = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            myInputs.screenHold = false;
            EnableInput(false);
        }
        
        
        if (myInputs.screenTouched || myInputs.screenHold)
        {
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
