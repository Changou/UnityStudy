using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] Transform _textPoint;
    [SerializeField] GameObject _prefab;

    string[] _data = new string[5];

    private void OnEnable()
    { 
        int count = Central._Inst.ListCount();

        if (count <= 0)
            return;

        for(int i = 0; i < count; i++)
        {
            Central._Inst.GetData(ref _data, i);

            GameObject data = Instantiate(_prefab);
            data.transform.SetParent(_textPoint);

            data.GetComponent<TextSetting>().SettingText(_data, i);
        }
    }
}
