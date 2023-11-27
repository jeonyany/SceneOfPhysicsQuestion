using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectMotion : MonoBehaviour
{
    public Button playBtn;
    private PrefabData_SO data;
    private float distance;
    private Vector3 target;
    private void Awake()
    {
        //playBtn = GameObject.Find("Input Canvas/play").GetComponent<Button>();
        //playBtn.onClick.AddListener(playBtnOnClick);
        data = ObjDataManager.Instance.currentData;
        //计算目标点
        distance = data.velocity * data.t;
        target = new Vector3(distance, 0, 0);
    }
    
    private void playBtnOnClick()
    {
        LateUpdate();
    }

    private void LateUpdate()
    {
        Time.timeScale = 1;
        
        transform.position = Vector3.MoveTowards(transform.localPosition, target, data.velocity*Time.deltaTime);

    }
}
