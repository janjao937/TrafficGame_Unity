using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleGreenState :VehicleBaseState 
{
    private float yOrigin = 0f;
    private int indexPath = 0;
    public VehicleGreenState(Path path,Transform target,Vehicle vehicle):base(path,target,vehicle)
    {
        yOrigin = vehicle.transform.position.y;
        lightType= LightType.Green;
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

        vehicle.transform.position += vehicle.transform.forward*vehicle.MoveSpeed*Time.deltaTime;//move forward
    }

    protected override VehicleBaseState ChangeToNextState()
    {
        //yellow
        return base.ChangeToNextState();
    }

    private void ChangeTarget()
    {
        if(indexPath<path.AllTransfroms.Count-1){
            indexPath++;
            target = path.AllTransfroms[indexPath];
            vehicle.Target = path.AllTransfroms[indexPath];//for view
        }
        else{
            indexPath = 0;
            target=path.AllTransfroms[indexPath];
            vehicle.Target=path.AllTransfroms[indexPath];//for view
        }
    }
    
}
