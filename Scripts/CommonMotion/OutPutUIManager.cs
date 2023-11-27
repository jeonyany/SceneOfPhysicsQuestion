using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OutPutUIManager : Singleton<OutPutUIManager>
{
    public Text time;
    public Text velocity;
    public Text distance;
    private PrefabData_SO data;
    private float realTime;//计时器
    private float dis;
    private bool isCounting = true;
    private GameObject obj;

    protected override void Awake() 
    {
        base.Awake();
        obj = ObjDataManager.Instance.SetObject();
        data = ObjDataManager.Instance.currentData;
        dis = data.t * data.velocity;
    }


    private void Update()
    {
        SetUIText();
    }

    private void SetUIText()
    {
        velocity.text = data.velocity.ToString();
        distance.text = obj.transform.position.x.ToString("f1");
        if (isCounting)
        {
            realTime += Time.deltaTime;
            if (obj.transform.position.x == dis)
            {
                isCounting = false;
                //Console.WriteLine("停止计时");
            }
            time.text = realTime.ToString("f1");
        }

    }

    
}
