using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    [SerializeField] private Path myPath = null;
    public Transform Target;

    [SerializeField] private bool stopPath = false;
    [SerializeField] private float stopDistance = 1f;
    public float MoveSpeed = 3f;
    public float RotateSpeed = 3f;

    private LightType currentLightType = LightType.Green;
    private VehicleBaseState vehicleState;

    private float yOrigin  = 0;
    private int indexPath = 0;

    public float StopDistance =>stopDistance;

    private void Awake()
    {
        yOrigin = transform.position.y;
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
        vehicleState = new VehicleGreenState(myPath,Target,this);
    }
    private void LoopState()
    {
        vehicleState.MovementState(currentLightType);
    }
    
    public bool NearTarget()=>Vector3.Distance(transform.position,Target.position)<=stopDistance;

    private void OnDrawGizmos()
    {
        if(Target==null) return;
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,stopDistance);
        
    }
    
}
