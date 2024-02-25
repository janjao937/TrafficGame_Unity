using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseTrafficState 
{
    private StateMode stateMode;
    //==
    protected TrafficLightControl trafficLightControl;
    protected Path controlPath;
    protected LightType lightType;
    protected bool canChangeState;
    protected float timeCount = 0;
    public BaseTrafficState(TrafficLightControl trafficLightControl,Path controlPath)
    {
        this.controlPath = controlPath;
        this.trafficLightControl = trafficLightControl;
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
        if(canChangeState)ExitState();
        
    }

    protected virtual void SetLight()
    {
        trafficLightControl.SetMeshLight.SetLight(this.lightType); //setLight
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
        return new BaseTrafficState(this.trafficLightControl,this.controlPath);
    }
    protected void ExitState()
    {
        stateMode = StateMode.Exit;
        canChangeState=false;
    }
}
/*
       
        Red   
            =set Light
            =cool down => running
            =Running
                stay red
                cool down&car running => red
        Green
            =setLight  
        Yellow slow
            =setLight
            =cool down => red
*/
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
