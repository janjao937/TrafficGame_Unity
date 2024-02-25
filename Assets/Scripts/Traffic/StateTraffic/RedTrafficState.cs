
using UnityEngine;

public class RedTrafficState:BaseTrafficState
{

    private float runningTime = 0;
    private float redTime = 0;
    private bool isRunning = false;
    public RedTrafficState(TrafficLightControl trafficLightControl,Path controlPath):base(trafficLightControl,controlPath)
    {

    }

    protected override void SetLight()
    {
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
            timeCount = runningTime;
        }
        else
        {
            timeCount = redTime;
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
