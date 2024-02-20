using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleYellowState:VehicleBaseState
{
    public VehicleYellowState(Path path,Transform target,Vehicle vehicle):base(path,target,vehicle)
    {
        lightType= LightType.Yellow;
    }

    protected override void VehicleAction()
    {
        base.VehicleAction();
    }
    protected override VehicleBaseState ChangeToNextState()
    {
        return base.ChangeToNextState();
    }
}
