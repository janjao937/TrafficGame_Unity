using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]private bool isStop = false;
    public List<Transform> AllTransfroms = default;

    public void setStop() => isStop = true;
    public void setStart() => isStop = false;

    void OnDrawGizmos()
    {
        if(AllTransfroms.Count<=0)return;
        
        // foreach(Transform t in allTransfroms){
        //     Gizmos.DrawWireSphere(t.position,0.5f);
            
        // }
        for(int i = 0;i<AllTransfroms.Count;i++){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AllTransfroms[i].position,0.5f);
            Gizmos.color = Color.blue;
            if(i==AllTransfroms.Count-1)return; 
            Gizmos.DrawLine(AllTransfroms[i].position,AllTransfroms[i+1].position);
        }
    }


}
