using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    [SerializeField] private Path ctrlPath;
    [SerializeField] private LightType currentLight = LightType.Red;

    private BaseTrafficState trafficState;

    private  void Awake()
    {
        if(ctrlPath==null) this.gameObject.SetActive(false);
        trafficState = new RedTrafficState();   
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
