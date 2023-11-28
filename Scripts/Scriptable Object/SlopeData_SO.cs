using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prefab", menuName = "Inventory/Slope Data")]// 生成物品属性资源

public class SlopeData_SO : ScriptableObject
{
    public GameObject model;
    public int angle;
    public int length = 0;
    public int height = 0;
    public int mass;
    public float friction;

    public Vector3 position;
    
}
