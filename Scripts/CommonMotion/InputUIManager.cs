using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUIManager : MonoBehaviour
{
    [Header("基本属性")]
    public InputField main;
    public InputField mass;
    public InputField velocity;
    public InputField time;
    public InputField position;

    [Header("UI")]
    public Button submitBtn;
    public GameObject playBtn;
    public GameObject inputPanel;
    public GameObject outputPanel;
    public Text quest;//题目文本
    private Dictionary<string, List<string>> param;//分析后的数据字典
    
    [Header("单位文本")]
    public Text timeUnit;
    public Text velocityUnit;

    private void Awake()
    {
        submitBtn.GetComponent<Button>().onClick.AddListener(SubmitBtnOnClick);
        param = SceneController.Instance.entityData;
        quest.text = SceneController.Instance.questText;
        CheckParams(param);
        position.text = "0,0,0";
        Time.timeScale = 0;
    }

    public void SubmitBtnOnClick()
    {   
        //修改当前实体属性
        PrefabData_SO data = new PrefabData_SO
        {
            mass = 1,
            velocity = float.Parse(velocity.text),
            t = float.Parse(time.text)
        };
        string tmp = position.text;
        if (tmp != "")
        {
            string[] tokens = new string[2];
            tokens = position.text.Split(',');
            data.position = new Vector3(float.Parse(tokens[0]),float.Parse(tokens[1]),float.Parse(tokens[2]));
        }
        else
        {
            data.position = new Vector3(0, 0, 0);
        }
                
        Time.timeScale = 1;

        
        inputPanel.SetActive(false);
        playBtn.SetActive(true);
        //outputUIPanel.SetActive(true);
        ObjDataManager.Instance.getCurrentData(data);
        ObjDataManager.Instance.CreateObject(main.text,data);
        outputPanel.SetActive(true);
        
    }

    public void CheckParams(Dictionary<string, List<string>> param)
    {
        if (param["物体"]!=null)
        {
            main.text = param["物体"][0];
        }
        foreach (string num in param["数值"])
        {
            if (num.Contains("m/s"))
                velocity.text = num.Substring(0,num.Length -3);
                velocityUnit.text = "速度：(m/s)";
            if (!num.Contains("m/s") && num.Contains("s"))
                time.text = num.Substring(0,num.Length - 1);
                timeUnit.text = "时间：(s)";
        }
    }                                                                                                                                                                      
}
