using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleYellowState:VehicleBaseState
{
    // private int indexPath = default;
    private float slowValue = 1.5f;
    private float slowSpeed = default;
    private float yOrigin = 0f;
    public VehicleYellowState(int indexPath,Path path,Transform target,Vehicle vehicle):base(indexPath,path,target,vehicle)
    {
        lightType= LightType.Yellow;
        yOrigin = vehicle.transform.position.y;
        // this.indexPath = currentIndexPath;
        slowSpeed = (vehicle.MoveSpeed-slowValue)>0?vehicle.MoveSpeed-slowValue:slowValue;
    }

    protected override void VehicleAction()
    {
        //follow waypoint
        if(NearTarget()){
            ChangeTarget();
        }
         Vector3 targetDir = (target.position - vehicle.transform.position).normalized;//find unit vector dir
        targetDir.y = yOrigin;//reset y dir
        Quaternion lookRotation = Quaternion.LookRotation(targetDir,Vector3.up);//find look rotation 
        vehicle.transform.rotation = Quaternion.Lerp(vehicle.transform.rotation, lookRotation, Time.deltaTime * vehicle.RotateSpeed);//rotate forward to target

        vehicle.transform.position += vehicle.transform.forward*slowSpeed*Time.deltaTime;//move forward
    }
    protected override VehicleBaseState ChangeToNextState()
    {
        //red
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
