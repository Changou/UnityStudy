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
        _text.text = $"<size=12><{value + 1}번></size>\n" +
                $"이름 : {data[0]}\n" +
                $"나이 : {data[4]}";
    }
    public void SettingAllDataText(string[]data) 
    {
        _text.text = 
                $"이름 : {data[0]}\n" +
                $"결혼 여부 : {data[1]}\n" +
                $"주소 : {data[2]} {data[3]}\n" +
                $"나이 : {data[4]}\n" +
                $"직업 : {data[5]}";
    }

    public void SettingText(string[] data)
    {
        _text.text =
                $"이름 : {data[0]}\n" +
                $"나이 : {data[4]}";
    }
}
