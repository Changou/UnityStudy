using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        if (!_IsLoad) _loadText.gameObject.SetActive(false);

        Setting();
    }

    void Setting()
    {
        LobbyDataSetting[] child = _textPoint.GetComponentsInChildren<LobbyDataSetting>();

        if (child != null)
        {
            for (int i = 0; i < child.Length; i++)
            {
                Destroy(child[i].gameObject);
            }
        }

        int count = Central._Inst.ListCount();

        if (count <= 0)
            return;

        _data = new string[Central._Inst.CallAddressFieldCnt()];

        for (int i = 0; i < count; i++)
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
        string path = EditorUtility.OpenFilePanel("주소록 파일 로드", "", "json");

        if (string.IsNullOrEmpty(path)) return;

        string[] fileName = path.Split("/");

        _loadText.text = fileName[fileName.Length - 1] + "Load";
        _loadText.gameObject.SetActive(true);

        Central._Inst.LoadFile(path);
        UIManager._Inst.PopUp(UIManager.POPUP.DETAIL, false);
        UIManager._Inst.Message(UIManager.MESSAGE.FILELOAD);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }
}
