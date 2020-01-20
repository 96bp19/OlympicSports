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
        defaultInputs = new Inputs(false);
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
            InputListeners?.Invoke(myInputs);
            EnableInput(false);

        }
       
        
    }


}

public struct Inputs
{
    public bool screenTouched;

    public Inputs(bool screenTouched)
    {
        this.screenTouched = screenTouched;
    }
}
