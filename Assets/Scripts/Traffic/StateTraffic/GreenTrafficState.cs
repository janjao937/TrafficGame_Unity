using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrafficState :BaseTrafficState
{
    public GreenTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath){}

    protected override void SetLight()
    {
        base.SetLight();
    }
    protected override void UpdateState()
    {
        base.UpdateState();
    }
    protected override BaseTrafficState ChangeToNextState()
    {
        return base.ChangeToNextState();
    }


}
