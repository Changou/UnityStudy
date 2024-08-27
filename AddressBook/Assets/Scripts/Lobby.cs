using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] Transform _textPoint;
    [SerializeField] GameObject _prefab;

    string[] _data;

    private void OnEnable()
    {
        Text[] child = _textPoint.GetComponentsInChildren<Text>();

        if(child != null)
        {
            for(int i = 0; i < child.Length; i++)
            {
                Destroy(child[i].gameObject);
            }
        }

        int count = Central._Inst.ListCount();

        if (count <= 0)
            return;

        _data = new string[Central._Inst.CallAddressFieldCnt()];

        for(int i = 0; i < count; i++)
        {
            Central._Inst.GetData(ref _data, i);

            GameObject data = Instantiate(_prefab);
            data.transform.SetParent(_textPoint);

            data.GetComponent<TextSetting>().SettingText(_data, i);
        }
    }
}
