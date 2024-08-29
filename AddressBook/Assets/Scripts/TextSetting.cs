using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetting : MonoBehaviour
{
    [SerializeField] Text _text;

    public void SettingText()
    {
        _text.text = "";
    }

    public void SettingText(string[] data,int value)
    {
        _text.text = $"<size=12><{value + 1}��></size>\n" +
                $"�̸� : {data[0]}\n" +
                $"���� : {data[4]}";
    }
    public void SettingAllDataText(string[]data) 
    {
        _text.text = 
                $"�̸� : {data[0]}\n" +
                $"��ȥ ���� : {data[1]}\n" +
                $"�ּ� : {data[2]} {data[3]}\n" +
                $"���� : {data[4]}\n" +
                $"���� : {data[5]}";
    }

    public void SettingText(string[] data)
    {
        _text.text =
                $"�̸� : {data[0]}\n" +
                $"���� : {data[4]}";
    }
}
