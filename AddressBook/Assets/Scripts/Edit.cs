using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit : AddAddress
{
    [SerializeField] Address _address;

    public string[] _data;
    public string _loadpath;

    public int _editNumber;

    public string _currentName;

    protected override void OnEnable()
    {
        Setting();
    }

    public void EditAddressList()
    {
        string name;
        bool marry;
        string county;
        string city;
        int age;
        string job;

        name = _inputName.text;

        if (_toggleMarry[0].isOn)
            marry = true;
        else
            marry = false;

        county = _drop[0].options[_drop[0].value].text;
        city = _drop[1].options[_drop[1].value].text;
        age = (int)_sliderAge.value;
        job = ToggleSelect();

        if (ErrorCheck())
        {
            return;
        }

        AddressClass address = new AddressClass(name, marry, county, city, age, job);

        if(!string.IsNullOrEmpty(_loadpath))
            Central._Inst.LoadFileEdit(_loadpath, address);
        else
            Central._Inst.CallEditAddress(_editNumber, address);

        UIManager._Inst.Message(UIManager.MESSAGE.EDIT);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }

    protected override bool ErrorCheck()
    {
        return base.ErrorCheck();
    }

    public void Setting()
    {
        if (Central._Inst.ListCount() == 0) return;

        string[] datas = new string[Central._Inst.CallAddressFieldCnt()];

        if(!string.IsNullOrEmpty(_loadpath))
            datas = _data;
        else
            Central._Inst.GetData(ref datas, _editNumber);

        _inputName.text = datas[0];
        _currentName = datas[0];
        if (datas[1].Equals("±‚»•"))
        {
            _toggleMarry[0].isOn = true;
            _toggleMarry[1].isOn = false;
        }
        else
        {
            _toggleMarry[1].isOn = true;
            _toggleMarry[0].isOn = false;
        }
        for(int i = 0; i < _drop[0].options.Count; i++)
        {
            if (_drop[0].options[i].text.Equals(datas[2]))
            {
                _drop[0].value = i;
                break;
            }
        }
        _address.ChangedCity();
        for (int i = 0; i < _drop[1].options.Count; i++)
        {
            if (_drop[1].options[i].text.Equals(datas[3]))
            {
                _drop[1].value = i;
                break;
            }
        }
        _sliderAge.value = int.Parse(datas[4]);

        Text[] toggleT = _toGJob.GetComponentsInChildren<Text>();
        for(int i = 0; i < toggleT.Length; i++)
        {
            if (toggleT[i].text.Equals(datas[5]))
            {
                toggleT[i].GetComponentInParent<Toggle>().isOn = true;
            }
            else
                toggleT[i].GetComponentInParent<Toggle>().isOn = false;
        }
    }
}
