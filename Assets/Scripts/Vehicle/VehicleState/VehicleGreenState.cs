using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleGreenState :VehicleBaseState 
{
    // private int indexPath = 0;
    public VehicleGreenState(int indexPath,Path path,Transform target,Vehicle vehicle):base(indexPath,path,target,vehicle)
    {
        lightType= LightType.Green;
    }
    protected override void VehicleAction()
    {
        //follow waypoint
        if(NearTarget()){
            ChangeTarget();
        }
        MoveTo(target,vehicle.MoveSpeed);
    }

    protected override VehicleBaseState ChangeToNextState()
    {
        return new VehicleYellowState(indexPath,path,target,vehicle);//yellow
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
