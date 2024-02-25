
using UnityEngine;

public class RedTrafficState:BaseTrafficState
{
    private bool isRunning = false;
    public RedTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath)
    {
        lightType = LightType.Red;
        isRunning = false;
    }

    protected override void SetLight()
    {
        ResetTimeCount(isRunning);
        base.SetLight();//next to Update
    }
    protected override void UpdateState()
    {
        if(timeCount<0)
        {
            timeCount -= Time.deltaTime;
        }
        else
        {
            isRunning = !isRunning;
            ResetTimeCount(isRunning);
        }
        
        LoopRed(isRunning);
    }
    private void ResetTimeCount(bool isRunning)
    {
        if(isRunning)
        {
            timeCount = trafficLightControl.RunningTime;
        }
        else
        {
            timeCount = trafficLightControl.RedTime;
        }
    }
    private void LoopRed(bool isRunning)
    {
        if(isRunning)RunningCar();
        else StopCar();
    }
    private void StopCar()
    {
        Debug.Log("car Stay 5 sec");
        Debug.Log("Red running");
    }
    private void RunningCar()
    {
        Debug.Log("change path to green 5 sec");//car running
    }

  
    protected override BaseTrafficState ChangeToNextState()
    {
        return new GreenTrafficState(this.trafficLightControl,controlPath);//Green
    }
}
