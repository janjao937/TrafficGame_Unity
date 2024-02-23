
public class RedTrafficState:BaseTrafficState
{
    public RedTrafficState():base(){}

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
