using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    [SerializeField] private Path ctrlPath;
    [SerializeField] private LightType currentLight = LightType.Red;
    [SerializeField] private MatchMeshLight matchMeshLight;

    private BaseTrafficState trafficState;

    //==property
    public float YellowTime = 5;
    public float RedTime = 5;
    public float RunningTime = 5;

    public MatchMeshLight SetMeshLight =>matchMeshLight;

    private  void Awake()
    {
        if(ctrlPath==null) this.gameObject.SetActive(false);
        trafficState = new RedTrafficState(this,ctrlPath);   
    }
    
    private void Update()
    {
        trafficState = trafficState.Process();
    }      
    private void ChangeLight()
    {
        //set next color state
        trafficState.InputChangeState();
    }



}
