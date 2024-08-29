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

        Central._Inst.GetData(ref data, _dataNumber);
        _popupDetail.GetComponentInChildren<TextSetting>().SettingAllDataText(data);

        _popupDetail.SetActive(true);
    }

    public void OnPopupRemove()
    {
        _popupRemove.SetActive(true);

        _popupRemove.GetComponentInChildren<Button>().onClick.AddListener(RemoveAddress);
    }

    public void OnPopupEdit()
    {
        _popupEdit.SetActive(true);
        _popupEdit.GetComponentInChildren<Button>().onClick.AddListener(EditOn);
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
