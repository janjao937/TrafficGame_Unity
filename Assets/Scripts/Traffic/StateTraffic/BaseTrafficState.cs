using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrafficState 
{
    public BaseTrafficState()
    {

    }

    public void TrafficLightPattern()
    {
     
    }

    protected void SetPath()
    {

    }
    
    protected BaseTrafficState ChangeState()
    {
        return new BaseTrafficState();
    }
}
