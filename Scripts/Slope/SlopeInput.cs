using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    [Header("物体定位")]
    public GameObject slope;
    public GameObject generatePoint;

    private void Awake()
    {
        submitBtn.GetComponent<Button>().onClick.AddListener(SubmitBtnOnClick);
        Time.timeScale = 0;
    }

    public void SubmitBtnOnClick()
    {
        Quaternion slopeAngle = Quaternion.Euler(0, 0, int.Parse(angle.text));
        slope.transform.localRotation = slopeAngle;

        slope.gameObject.SetActive(true);
        

        SlopeData_SO data = new SlopeData_SO
        {
            angle = int.Parse(angle.text),
            mass = int.Parse(mass.text),
            friction = float.Parse(friction.text),
            position = generatePoint.transform.position
        };

        Time.timeScale = 1;

        inputPanel.SetActive(false);
        SlopeData.Instance.getCurrentData(data);
        SlopeData.Instance.CreateObject(main.text, data);
        outputPanel.SetActive(true);
    }
}
