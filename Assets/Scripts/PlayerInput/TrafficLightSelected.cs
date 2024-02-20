using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSelected : MonoBehaviour
{
    [SerializeField] private TrafficLightControl selectedTrafficLight = null;
    [SerializeField] private LayerMask canSelectLayermask = default;


    private void Start()
    {
        PlayerInput.Instance.OnMouseSelect+=HandleSelection;
    }

    private void HandleSelection(Vector2 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit = default;
        float maxDistance = float.MaxValue;
        bool isSelect =  Physics.Raycast(ray,out hit,maxDistance,canSelectLayermask);
                    
        if(isSelect){
            //getComponent hit;
            Debug.Log(hit.transform.gameObject.name);
        }
    }

}
