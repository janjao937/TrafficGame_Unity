using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseTrafficState 
{
    private StateMode stateMode;
    //==
    protected LightType lightType;
    protected bool canChangeState;
    protected float timeCount = 0;
    public BaseTrafficState()
    {
        this.stateMode = StateMode.Enter;
        this.canChangeState = true;
    }

    public BaseTrafficState Process()
    {
    
        if(stateMode==StateMode.Enter)
        {
            SetLight();
            return this;
        }
        if(stateMode ==StateMode.Update)
        {
            UpdateState();
            return this;
        }
        return ChangeToNextState();
    }
    
    public void InputChangeState()
    {
        if(canChangeState)stateMode = StateMode.Exit;
        
    }

    protected virtual void SetLight()
    {
       
        //Red   
            //set Light
            //cool down => running
        //Running
            //stay red
            //cool down => red
        //Green
            //setLight  
        //Yellow slow
            //setLight
            //cool down => red
        stateMode = StateMode.Update;
    }
    protected virtual void UpdateState()
    {
        //cool down
        Debug.Log("Update");
    }
    protected virtual BaseTrafficState ChangeToNextState()
    {
        //change state
        return new BaseTrafficState();
    }
}

/*
    
        if(stateMode==StateMode.Enter)
        {
            SetLight();
            return this;
        }
        if(stateMode ==StateMode.Update)
        {
            UpdateState();
            return this;
        }
        return ChangeToNextState();
*/
