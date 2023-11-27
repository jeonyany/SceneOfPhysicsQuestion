using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class AnalysisUIManager : Singleton<AnalysisUIManager>
{
    [Header("文件上传")]
    public Button uploadBtn;
    public Text filePathText;
    public Button analysisBtn;
    [Header("实体面板")]
    public Transform entityTransform;
    public GameObject entityObject;
    public Dictionary<string, List<string>> entityData = new Dictionary<string, List<string>>();
    public Text selectedSceneName;
    public Text questText;

    [Header("菜单")]
    public Button submitBtn;
    public Button AddBtn;
    public Button ClearBtn;
    public GameObject sceneController;

    [Header("实体列表")]
    public List<GameObject> EntityClones;

    private string questString;
    private void Start()
    {
        uploadBtn.onClick.AddListener(UploadBtnOnClick);
        analysisBtn.onClick.AddListener(SetUpAnalysisEntityList);
        submitBtn.onClick.AddListener(SubmitBtnOnClick);
        AddBtn.onClick.AddListener(AddBtnOnClick);
        ClearBtn.onClick.AddListener(ClearContent);
    }

    protected override void Awake()
    {
        base.Awake();
        ClearContent();
    }

    /// <summary>
    /// 上传按钮点击事件
    /// </summary>
    private void UploadBtnOnClick()
    {
        var filePath = EditorUtility.OpenFilePanel("选择打开文件", Application.streamingAssetsPath, "txt");
        if (filePath == "")
        {
            filePathText.color = Color.red;
            filePathText.text = "选择文件不能为空";
        }
        else
        {
            filePathText.color = Color.blue;
            filePathText.text = "filePath:" + filePath;
            ReadFile(filePath);
        }

    }

    /// <summary>
    /// 文件解析
    /// </summary>
    /// <param name="path">路径</param>
    private void ReadFile(string path)
    {
        StreamReader tmpReader = new StreamReader(path);
        questString = tmpReader.ReadLine();
        string line = tmpReader.ReadLine();
        int linCount = int.Parse(line);
        string tmpLine;
        string[] tmpArray;
        for (int i = 0; i < linCount; i++)
        {
            tmpLine = tmpReader.ReadLine();
            tmpArray = tmpLine.Split();
            if (entityData.ContainsKey(tmpArray[0]))
            {
                entityData[tmpArray[0]].Add(tmpArray[1]);
            }
            else
            {
                List<string> tmp = new List<string>();
                tmp.Add(tmpArray[1]);
                entityData.Add(tmpArray[0], tmp);
            }
        }
    }

    /// <summary>
    /// 生成解析后实体列表
    /// </summary>
    public void SetUpAnalysisEntityList()
    {
        if (entityData.Count == 0)
        {
            filePathText.color = Color.red;
            filePathText.text = "解析内容为空";
            return;
        }
        foreach (Transform item in entityTransform)
        {
            Destroy(item.gameObject);
        }
        questText.gameObject.SetActive(true);
        questText.text = questString;
        //entityTransform.gameObject.SetActive(true);
        foreach (var data in entityData)
        {
            string name = data.Key;
            for (int i = 0; i < entityData[name].Count; i++)
            {
                var q = Instantiate(entityObject, entityTransform);
                var value = data.Value[i];
                q.GetComponent<EntityUIObj>().SetUpEntityData(name, value);
                EntityClones.Add(q);
            }
        }
    }


    /// <summary>
    /// 获得更新后的提交数据
    /// </summary>
    public void UpdateEntityData()
    {
        Dictionary<string, List<string>> UpdatedData = new Dictionary<string, List<string>>();

        foreach (var entity in EntityClones)
        {
            if (entity != null)
            {
                // Debug.Log("----------------------------------------------------");
                // Debug.Log(entity.GetComponent<EntityUIObj>().GetCurrentOption());
                // Debug.Log(entity.GetComponent<EntityUIObj>().propertyText.GetComponent<InputField>().text.ToString());
                EntityUIObj currentEntityData = entity.gameObject.GetComponent<EntityUIObj>();
                string name = currentEntityData.GetCurrentOption();
                string property = currentEntityData.propertyText.GetComponent<InputField>().text.ToString();
                if (UpdatedData.ContainsKey(name))
                {
                    UpdatedData[name].Add(property);
                }
                else
                {
                    List<string> tmp = new List<string>();
                    tmp.Add(property);
                    UpdatedData.Add(name, tmp);
                }
            }

        }
        entityData = UpdatedData;
    }

    /// <summary>
    /// 提交
    /// </summary>
    private void SubmitBtnOnClick()
    {
        UpdateEntityData();
        Debug.Log(selectedSceneName.text);
        SceneController.Instance.LoadScene(selectedSceneName.text, entityData);
        SceneController.Instance.questText = questText.text;
        //sceneController.GetComponent<SceneController>().LoadScene(selectedSceneName.text);
    }

    /// <summary>
    /// 添加
    /// </summary>
    private void AddBtnOnClick()
    {
        //entityTransform.gameObject.SetActive(true);
        var q = Instantiate(entityObject, entityTransform);
        q.GetComponent<EntityUIObj>().SetUpEntityData("", "");
        EntityClones.Add(q);
    }


    /// <summary>
    /// 清空实体Content列表
    /// </summary>
    public void ClearContent()
    {
        foreach (Transform item in entityTransform)
        {
            Destroy(item.gameObject);
        }
        questText.text = null;
        filePathText.text = null;
        entityData.Clear();
        EntityClones.Clear();
    }

}
