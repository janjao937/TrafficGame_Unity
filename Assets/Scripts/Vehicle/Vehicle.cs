using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private VehicleBaseState vehicleState;
   
    [Header("Vehicle State")]
    [SerializeField]private LightType currentLightState = LightType.Green;
    public Transform Target = default;
    [SerializeField] private Path myPath = null;//firstPathRef
    [SerializeField] private bool stopPath = false;
    [SerializeField] private float stopDistance = 1f;
    
    [Header("Speed")]
    public float MoveSpeed = 3f;
    public float RotateSpeed = 3f;

    public float StopDistance =>stopDistance;

    private void Awake()
    {

    }

    private void Start()
    {
        if(myPath==null) gameObject.SetActive(false);
        Target=myPath.AllTransfroms[0];
        SetupState();
    }


    private void Update()
    {
        // if(Target == null) return;
    
        if(!stopPath)
        {

            LoopState();
        }  

    }
    //movement state
    private void SetupState(){
        vehicleState = new VehicleGreenState(0,myPath,Target,this);
    }
    private void LoopState()
    {
        vehicleState = vehicleState.MovementState(currentLightState);
    }
    
    // public bool NearTarget()=>Vector3.Distance(transform.position,Target.position)<=stopDistance;

    private void OnDrawGizmos()
    {
        if(Target==null) return;
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,stopDistance);
        
    }
    
}
