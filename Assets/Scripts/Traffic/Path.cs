using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]private Path nextPath = default;
    [SerializeField]private LightType currentLightType = LightType.Green;
    public List<Transform> AllTransfroms = default;

    // [SerializeField]private bool isStop = false;
    // public void setStop() => isStop = true;
    // public void setStart() => isStop = false;
    public LightType GetCurrentLightType=>currentLightType;
    public LightType SetCurrentLightType {set =>currentLightType=value;}

    public Path NextPath
    {
        get{
            if(nextPath==null){
                return null;
            }
            return nextPath;
        }
    }

    private void OnDrawGizmos()
    {
        if(AllTransfroms.Count<=0)return;
        
        for(int i = 0;i<AllTransfroms.Count;i++){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AllTransfroms[i].position,0.5f);
            Gizmos.color = Color.blue;
            if(i==AllTransfroms.Count-1)return; 
            Gizmos.DrawLine(AllTransfroms[i].position,AllTransfroms[i+1].position);
        }
    }


}
