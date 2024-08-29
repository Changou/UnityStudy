using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] Transform _textPoint;
    [SerializeField] GameObject _prefab;
    [SerializeField] InputField _fileName;
    [SerializeField] Text _loadText;

    string[] _data;

    public bool _IsLoad;

    private void Awake()
    {
        _IsLoad = false;
    }

    private void OnEnable()
    {
        if (_IsLoad) return;

        _loadText.gameObject.SetActive(false);

        LobbyDataSetting[] child = _textPoint.GetComponentsInChildren<LobbyDataSetting>();

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
            data.transform.localScale = Vector3.one;

            data.transform.GetChild(0).GetChild(0).GetComponent<TextSetting>().SettingText(_data, i);
            data.GetComponent<LobbyDataSetting>()._dataNumber = i;
        }
    }

    public void LoadFile()
    {
        _IsLoad = true;
        string path = "";
        if (Central._Inst.FileSearch(ref path, _fileName.text))
        {
            UIManager._Inst.Message(UIManager.MESSAGE.FILELOADFAIL);
            return;
        }

        LobbyDataSetting[] child = _textPoint.GetComponentsInChildren<LobbyDataSetting>();

        if (child != null)
        {
            for (int i = 0; i < child.Length; i++)
            {
                Destroy(child[i].gameObject);
            }
        }

        string[] data = new string [Central._Inst.CallAddressFieldCnt()];

        Central._Inst.FileLoad(ref data, path);

        GameObject dataObj = Instantiate(_prefab);
        dataObj.transform.SetParent(_textPoint);
        dataObj.transform.localScale = Vector3.one;

        dataObj.transform.GetChild(0).GetComponentInChildren<TextSetting>().SettingText(data);
        dataObj.GetComponent<LobbyDataSetting>()._fileLoadData = data;

        _loadText.gameObject.SetActive(true);
        string[] filename = path.Split("/");

        dataObj.GetComponent<LobbyDataSetting>()._fileName = filename[filename.Length - 1];
        dataObj.GetComponent<LobbyDataSetting>()._filePath = path;
        _loadText.text = filename[filename.Length - 1] + " Load";
    }
}
