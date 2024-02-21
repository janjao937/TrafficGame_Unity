using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleYellowState:VehicleBaseState
{
    // private int indexPath = default;
    private float slowValue = 1.5f;
    private float slowSpeed = default;
    public VehicleYellowState(int indexPath,Path path,Transform target,Vehicle vehicle):base(indexPath,path,target,vehicle)
    {
        lightType= LightType.Yellow;
        // yOrigin = vehicle.transform.position.y;
        // this.indexPath = currentIndexPath;
        slowSpeed = (vehicle.MoveSpeed-slowValue)>0?vehicle.MoveSpeed-slowValue:slowValue;
    }

    protected override void VehicleAction()
    {
        if(NearTarget()){
            ChangeTarget();
        }
        MoveTo(target,slowSpeed);
    }
    protected override VehicleBaseState ChangeToNextState()
    {
        // return new VehicleRedState(indexPath,path,target,vehicle);//red
        return new VehicleGreenState(indexPath,path,target,vehicle);
    }
    private void ChangeTarget()
    {
        if(indexPath<path.AllTransfroms.Count-1){
            indexPath++;
        }
        else{
            indexPath = 0;
            ChangePath();
        }
        target=path.AllTransfroms[indexPath];
        vehicle.Target=path.AllTransfroms[indexPath];//for view
    }

    private void ChangePath()
    {
        if(path.NextPath)
        {
            path = path.NextPath;
        }
    }
}
