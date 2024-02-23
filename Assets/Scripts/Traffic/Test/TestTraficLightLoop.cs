using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTraficLightLoop : MonoBehaviour
{   
    [SerializeField]private float timeCount = 0f;
    
    private Action finishTimeCount = default;
    private int i = 0;

    [ContextMenu("Count Time")]
    private void TestFunction()
    {
        StartCoroutine(CountTime());
        finishTimeCount += Finish;
    }

    private IEnumerator CountTime()
    {
        
        yield return new WaitForSeconds(timeCount);
        finishTimeCount?.Invoke();
        
    }

    private void Finish()
    {
        Debug.Log("FINISH");
        finishTimeCount -= Finish;
    }
}
