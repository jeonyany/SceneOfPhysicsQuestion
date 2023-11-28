using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SlopeData : Singleton<SlopeData>
{
     public List<SlopeData_SO> prefabsList = new List<SlopeData_SO>();
     public SlopeData_SO currentData;
     private Dictionary<int, string> inputsIndex = new Dictionary<int, string>()
     {
          {0,"斜面/斜坡"},
          {1,"物体"}

     };

     public GameObject res;
     public PhysicMaterial material;
     //获得当前data
     public void getCurrentData(SlopeData_SO data)
     {
          currentData = data;
     }
     public void CreateObject(string name, SlopeData_SO data)
     {
          material.staticFriction = data.friction;
          foreach (var item in inputsIndex)
          {
               if (item.Value.Contains(name))
               {
                    res = Instantiate(prefabsList[item.Key].model);
                    res.GetComponent<Rigidbody>().mass = data.mass;
                    //添加脚本、碰撞体组件
                    res.AddComponent<SlopeMotion>();
                    res.AddComponent<BoxCollider>();
                    //修改基本transform信息
                    res.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    Quaternion slopeAngle = Quaternion.Euler(0, 0, data.angle);
                    res.transform.localRotation = slopeAngle;
                    res.transform.position = data.position;
                    res.GetComponent<Rigidbody>().isKinematic = false;
                    //设置材质
                    res.GetComponent<BoxCollider>().material = material;
               }
          }
     }

     public GameObject SetObject()
     {
          return res;
     }
}
