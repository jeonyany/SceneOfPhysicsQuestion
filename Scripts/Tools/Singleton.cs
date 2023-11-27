using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance; // 所有的manager类型都可以用作泛型T

    // 外部访问
    public static T Instance
    {
        get { return instance; }
    }
    
    // protected 只允许继承类可以访问
    // virtual 虚函数 可以在继承类中重写(override)
    protected virtual void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = (T) this;
    }

    // 返回当前泛型单例是否生成
    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    // 如果场景中有多个单例模式则销毁
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null; // 如果当前实例被销毁则设置instance为空 --> 清空 instance变量
        }
    }
}