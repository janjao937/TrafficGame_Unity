using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRedState : VehicleBaseState
{
    public VehicleRedState(int indexPath, Path path, Transform target, Vehicle vehicle) : base(indexPath, path, target, vehicle)
    {
        this.lightType = LightType.Red;
    }

    protected override void VehicleAction()
    {
        base.VehicleAction();
    }

    protected override VehicleBaseState ChangeToNextState()
    {
        return new VehicleGreenState(indexPath,path,target,vehicle);//green
    }
}
