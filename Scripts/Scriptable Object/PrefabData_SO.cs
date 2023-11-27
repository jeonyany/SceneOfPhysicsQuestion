using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prefab", menuName = "Inventory/Prefab Data")]// 生成物品属性资源
public class PrefabData_SO : ScriptableObject
{
    public GameObject model;//模型
    public int mass; //质量
    public float velocity;//速度
    public float t;//时间
    public Vector3 position;//初始位置

}
