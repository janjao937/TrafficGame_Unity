using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMeshLight : MonoBehaviour
{
    [SerializeField] private LightType onLightType = LightType.Red;
    [SerializeField] private List<MeshRenderer> allLight = new List<MeshRenderer>();

    private Dictionary<LightType,MeshRenderer> dicMesh = new Dictionary<LightType, MeshRenderer>();
    private LightManager lightManager;

    void Awake()
    {
        lightManager = FindObjectOfType<LightManager>();
    }

    private void Start()
    {
        SetMeshLight();//test
    }
    [ContextMenu("SetMeshLight")]//test
    private void SetMeshLight()
    {
        int i = 0;
        foreach(var mat in lightManager.MatDic)
        {
            if(onLightType==mat.Value.LightType){
                allLight[i].material = mat.Value.On;
            }
            else{
                allLight[i].material = mat.Value.Off;
            }
            i++;
        }
    }

    //for setLight
    public void SetLight(LightType light)
    {
        //set on selected light
        //set off other
        this.onLightType = light;
        SetMeshLight();
    }
    




}
