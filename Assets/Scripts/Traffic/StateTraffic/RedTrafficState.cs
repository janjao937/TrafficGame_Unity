
using UnityEngine;

public class RedTrafficState:BaseTrafficState
{
    protected bool isCarRunning = false;
    public RedTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath)
    {
        isCarRunning = false;
        timeCount = 5;//runningTime
    }

    protected override void SetLight()
    {
        base.SetLight();
    }
    protected override void UpdateState()
    {
        // base.UpdateState();
         if(isCarRunning)
         {
            Debug.Log("car Stay 5 sec");
         }
         else
         {
            Debug.Log("change path to green 5 sec");//car running
         }
    }

  
    protected override BaseTrafficState ChangeToNextState()//Green
    {
        return base.ChangeToNextState();
    }
}
