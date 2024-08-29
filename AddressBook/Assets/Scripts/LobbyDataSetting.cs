using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDataSetting : MonoBehaviour
{
    public int _dataNumber;

    [SerializeField] GameObject _popupDetail;
    [SerializeField] GameObject _popupRemove;
    [SerializeField] GameObject _popupEdit;
    [SerializeField] Edit _edit;
    public string[] _fileLoadData;
    public string _fileName;
    public string _filePath;

    private void Awake()
    {
        _popupDetail = GameObject.Find("PopUp").transform.GetChild((int)UIManager.POPUP.DETAIL).gameObject;
        _popupRemove = GameObject.Find("PopUp").transform.GetChild((int)UIManager.POPUP.REMOVE).gameObject;
        _popupEdit = GameObject.Find("PopUp").transform.GetChild((int)UIManager.POPUP.EDIT).gameObject;
        _edit = GameObject.Find("Panel").transform.GetChild(((int)UIManager.POPUP.EDIT) + 1).GetComponent<Edit>();
    }

    public void OnPopupDetail()
    {
        string[] data = new string[Central._Inst.CallAddressFieldCnt()];

        if (!string.IsNullOrEmpty(_filePath))  //파일을 로드했을 경우
        {
            _popupDetail.GetComponentInChildren<TextSetting>().SettingAllDataText(_fileLoadData);
        }
        else
        {
            Central._Inst.GetData(ref data, _dataNumber);
            _popupDetail.GetComponentInChildren<TextSetting>().SettingAllDataText(data);
        }
        _popupDetail.SetActive(true);
    }

    public void OnPopupRemove()
    {
        _popupRemove.SetActive(true);
        if(!string.IsNullOrEmpty(_filePath))
        {
            _popupRemove.GetComponentInChildren<Button>().onClick.AddListener(RemoveAddressLoadFile);
        }
        _popupRemove.GetComponentInChildren<Button>().onClick.AddListener(RemoveAddress);
    }

    public void OnPopupEdit()
    {
        _popupEdit.SetActive(true);
        if (!string.IsNullOrEmpty(_filePath))
        {
            _popupEdit.GetComponentInChildren<Button>().onClick.AddListener(EditOnLoadFile);
        }
        _popupEdit.GetComponentInChildren<Button>().onClick.AddListener(EditOn);
    }

    void RemoveAddressLoadFile()
    {
        Central._Inst.DeleteFile(_filePath);
        GameObject.Find("Lobby").GetComponent<Lobby>()._IsLoad = false;

        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
        UIManager._Inst.Message(UIManager.MESSAGE.REMOVE);
    }

    void EditOnLoadFile()
    {
        _edit._data = _fileLoadData;
        _edit._loadpath = _filePath;
        UIManager._Inst.Show_Only(UIManager.UI.EDIT);
    }

    void EditOn()
    {
        _edit._editNumber = _dataNumber;
        UIManager._Inst.Show_Only(UIManager.UI.EDIT);
    }

    void RemoveAddress()
    {
        Central._Inst.CallRemoveAddress(_dataNumber);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
        UIManager._Inst.Message(UIManager.MESSAGE.REMOVE);
    }
}
