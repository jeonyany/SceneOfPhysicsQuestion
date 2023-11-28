using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeOutput : MonoBehaviour
{
    public Text time;
    public Text velocity;

    private SlopeData_SO data;
    private float realTime;//计时器
    private float dis;
    private bool isCounting;
    private GameObject obj;

    void Awake()
    {
        obj = SlopeData.Instance.SetObject();
        data = SlopeData.Instance.currentData;
        isCounting = true;
        //dis = data.t * data.velocity;
    }


    private void Update()
    {
        SetUIText();
    }

    private void SetUIText()
    {
        velocity.text = Math.Abs(obj.GetComponent<Rigidbody>().velocity.x).ToString("f1");
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
