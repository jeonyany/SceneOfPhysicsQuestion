using System.Collections.Generic;
using UnityEngine;

public class ObjDataManager : Singleton<ObjDataManager>
{
     public List<PrefabData_SO> prefabsList = new List<PrefabData_SO>();
     public PrefabData_SO currentData;
     private Dictionary<int, string> inputsIndex = new Dictionary<int, string>()
     {
          {0,"木块/物体"},
          {1,"小车/汽车"}

     };

     public GameObject res;

     //获得当前data
     public void getCurrentData(PrefabData_SO data)
     {
          currentData = data;
     }
     public void CreateObject(string name,PrefabData_SO data)
     {
          foreach (var item in inputsIndex)
          {
               if (item.Value.Contains(name))
               {
                    res = Instantiate(prefabsList[item.Key].model);
                    res.GetComponent<Rigidbody>().mass = data.mass;
                    res.AddComponent<ObjectMotion>();
               }
          }
     }

     public GameObject SetObject()
     {
          return res;
     }

}
