using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    private Dictionary<string, string> sceneData = new Dictionary<string, string>();
    public Dictionary<string, List<string>> entityData;
    public string questText;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        sceneData.Add("匀速直线运动","CommonMotion");
        sceneData.Add("斜坡-滑块模型", "Slope");
    }
    
    #region 场景加载
    public void LoadScene(string scene, Dictionary<string, List<string>> data)
    {
        string tmp = sceneData[scene];
        Debug.Log(tmp);
        if (tmp != "")
        {
            this.SetEntityData(data);
            SceneManager.LoadSceneAsync(tmp);
        }
    }

    public void LoadScene(string scene)
    {
        string tmp = sceneData[scene];
        Debug.Log(tmp);
        if (tmp != "")
        {
            SceneManager.LoadSceneAsync(tmp);
        }
    }
    
    public void LoadMain()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    #endregion

    #region 实体数据跨场景传输
    public void SetEntityData(Dictionary<string, List<string>> data)
    {
        if (entityData != null)
        {
            Debug.LogError("切换数据不为空，上一次切换场景的数据没有被读取");
        }
        entityData = data;
    }

    public Dictionary<string, List<string>> GetEntityData()
    {
        Dictionary<string, List<string>> tmpData = entityData;
        entityData = null;
        return tmpData;
    }
    #endregion
}
