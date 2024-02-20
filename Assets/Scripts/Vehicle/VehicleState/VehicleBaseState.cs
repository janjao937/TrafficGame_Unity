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

    public LightType LightType{get => lightType;}

    public VehicleBaseState(Path path,Transform target,Vehicle vehicle)
    {
        this.path = path;
        this.target = target;
        this.vehicle = vehicle;
        this.lightType = LightType.Base;
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
        return new VehicleGreenState(path,target,vehicle);
    }
    protected bool NearTarget()=>Vector3.Distance(vehicle.transform.position,target.transform.position)<=vehicle.StopDistance;

}
