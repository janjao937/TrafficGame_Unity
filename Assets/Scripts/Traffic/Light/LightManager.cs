using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
   [SerializeField] private List<MatLightOnOff> allMatLightOnOffs = default;

    private Dictionary<LightType,MatLightOnOff> matDic = new Dictionary<LightType, MatLightOnOff>();

    private void Awake()
    {
        InsertMatDic();   
    }

    private void InsertMatDic()
    {
        foreach(var i in allMatLightOnOffs)
        {
            matDic.Add(i.LightType,i);
        }
    }

    public MatLightOnOff GetMatLightOnOff(LightType lightType)
    {
        return matDic[lightType];
    }
}
