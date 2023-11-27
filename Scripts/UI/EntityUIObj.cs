using System;
using UnityEngine;
using UnityEngine.UI;

public class EntityUIObj : MonoBehaviour
{
    public Text nameText;
    public GameObject propertyText;
    public Dropdown dropdown;

    public void SetUpEntityData(string name, string value)
    {
        nameText.text = name;
        propertyText.GetComponent<InputField>().text = value;
        dropdown.value = CheckDropdownValue(name);
    }

    public void DeleteObject()
    {
        Destroy(this.gameObject);
    }

    public int CheckDropdownValue(string property)
    {   
        Debug.Log(property);
        if (property.Equals("场景"))
            return 1;
        else if (property == "属性")
            return 2;
        else if (property == "数值")
            return 3;
        else return 0;
    }

    public string GetCurrentOption()
    {
        return dropdown.captionText.text;
    }
}
