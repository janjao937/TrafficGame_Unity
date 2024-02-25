using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrafficState :BaseTrafficState
{
    public GreenTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath)
    {
        lightType = LightType.Green;
    }

    protected override void SetLight()
    {
        base.SetLight();//next to update
    }
    protected override void UpdateState()
    {
        Debug.Log("Green");
    }
    protected override BaseTrafficState ChangeToNextState()
    {
        return new YellowTrafficState(this.trafficLightControl,this.controlPath);//yellow
    }


}
