using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBaseState 
{
    //(path speed target lightType)
    protected Path path;
    protected Vehicle vehicle;
    protected Transform target;
    protected LightType lightType;
    protected int indexPath = 0;
    protected float yOrigin = 0;

    public LightType LightType{get => lightType;}

    public VehicleBaseState(int indexPath,Path path,Transform target,Vehicle vehicle)
    {
        this.path = path;
        this.target = target;
        this.vehicle = vehicle;
        this.indexPath = indexPath;
        this.lightType = LightType.Base;
        this.yOrigin = vehicle.transform.position.y;
    }
    public VehicleBaseState MovementState(LightType currentType){

        if(currentType==lightType){
            VehicleAction();
            return this;
        }
        else
        {
            return ChangeToNextState();
        }
    }
    
    protected virtual void VehicleAction()
    {
        //Wander    Green
        //speed--   Yellow
        //stop      Red
         Debug.Log("BaseState:VehicleAction");
    }
    protected virtual VehicleBaseState ChangeToNextState()
    {
        return new VehicleGreenState(indexPath,path,target,vehicle);
    }
    protected bool NearTarget()=>Vector3.Distance(vehicle.transform.position,target.transform.position)<=vehicle.StopDistance;  

    protected void MoveTo(Transform target,float speed)
    {
        Vector3 targetDir = (target.position - vehicle.transform.position).normalized;//find unit vector dir
        targetDir.y = yOrigin;//reset y dir
        Quaternion lookRotation = Quaternion.LookRotation(targetDir,Vector3.up);//find look rotation 
        vehicle.transform.rotation = Quaternion.Lerp(vehicle.transform.rotation, lookRotation, Time.deltaTime * vehicle.RotateSpeed);//rotate forward to target

        vehicle.transform.position += vehicle.transform.forward*speed*Time.deltaTime;//move forward
    }

}
