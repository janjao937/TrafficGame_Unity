using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    [SerializeField] private Path ctrlPath;

    private  void Awake()
    {
        if(ctrlPath==null) this.gameObject.SetActive(false);   
    }
    private void Update()
    {

    }      
    private void ChangeLight()
    {
        //set next color state
    }


}
