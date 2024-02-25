using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTrafficState : BaseTrafficState
{
    public YellowTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath)
    {
        lightType = LightType.Yellow;
    }

    protected override void SetLight()
    {
        timeCount = trafficLightControl.YellowTime;
        base.SetLight();//next to update
    }

    protected override void UpdateState()
    {
        base.UpdateState();
        if(timeCount > 0)
        {
            timeCount-=Time.deltaTime;
            Debug.Log("Yellow");
        }
        else{
            ExitState();
        }
    }
    protected override BaseTrafficState ChangeToNextState()
    {
        return new RedTrafficState(this.trafficLightControl,this.controlPath);//red
    }
}
