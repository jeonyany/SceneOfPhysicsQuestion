using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeOutput : MonoBehaviour
{
    public Text mass;
    public Text velocity;
    public Text angle;
    public Text friction;

    private SlopeData_SO data;
    
    private GameObject obj;

    public GameObject slope;

    void Awake()
    {
        obj = SlopeData.Instance.SetObject();
        data = SlopeData.Instance.currentData;
    }


    private void Update()
    {
        SetUIText();
    }

    private void SetUIText()
    {
        velocity.text = Math.Abs(obj.GetComponent<Rigidbody>().velocity.x).ToString("f1") + "m/s";
        mass.text = data.mass.ToString() + "kg";
        angle.text = data.angle.ToString() + "度";
        friction.text = data.friction.ToString();
    }

}
