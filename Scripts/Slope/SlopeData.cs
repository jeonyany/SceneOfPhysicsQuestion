using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeData : Singleton<SlopeData>
{
    public List<SlopeData_SO> prefabsList = new List<SlopeData_SO>();
     public SlopeData_SO currentData;
     private Dictionary<int, string> inputsIndex = new Dictionary<int, string>()
     {
          {0,"木块/物体"},
          {1,"斜面/斜坡"}

     };

     //获得当前data
     public void getCurrentData(SlopeData_SO data)
     {
          currentData = data;
     }
     public void CreateObject(string name,SlopeData_SO data)
     {
          foreach (var item in inputsIndex)
          {
               if (item.Value.Contains(name))
               {
                    
               }
          }
     }

}
