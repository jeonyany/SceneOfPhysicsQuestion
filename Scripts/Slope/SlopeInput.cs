using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeInput : MonoBehaviour
{
    [Header("基本属性")]
    public InputField main;
    public InputField angle;
    public InputField mass;
    public InputField friction;

    [Header("UI")]

    public Button submitBtn;
    public GameObject playBtn;
    public GameObject inputPanel;
    public GameObject outputPanel;
    public Text quest;//题目文本
    private Dictionary<string, List<string>> param;//分析后的数据字典

    private void Awake()
    {

    }

    public void SubmitBtnOnClick()
    {
        SlopeData_SO data = new SlopeData_SO
        {
            angle = int.Parse(angle.text),
            mass = int.Parse(mass.text),
            friction = float.Parse(friction.text)
        };

    }
}
