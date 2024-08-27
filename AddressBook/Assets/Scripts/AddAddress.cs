using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAddress : MonoBehaviour
{
    [Header("주소록 추가")]
    [SerializeField] protected InputField _inputName;
    [SerializeField] protected Toggle[] _toggleMarry;
    [SerializeField] protected Dropdown[] _drop;
    [SerializeField] protected Slider _sliderAge;
    [SerializeField] protected ToggleGroup _toGJob;

    [SerializeField] protected Duplication _dupName;

    protected virtual void OnEnable()
    {
        _inputName.text = "";
        foreach(Toggle toggle in _toggleMarry)
        {
            toggle.isOn = false;
        }
        _drop[0].value = 0;
        _sliderAge.value = _sliderAge.minValue;
    }

    public void CentralCallAdd()
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

        Central._Inst.AddCallArchive(address);
        UIManager._Inst.Message(UIManager.MESSAGE.SUCCESS);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }

    protected virtual bool ErrorCheck()
    {
        if (!_dupName._isCheck) 
        {
            UIManager._Inst.Message(UIManager.MESSAGE.DUPLICATIONNULLERROR);
            return true;
        }
        if ((!_toggleMarry[0].isOn && !_toggleMarry[1].isOn) ||
            (_toggleMarry[0].isOn && _toggleMarry[1].isOn))
        {
            UIManager._Inst.Message(UIManager.MESSAGE.NULLERROR);
            return true;
        }

        return false;
    }

    protected string ToggleSelect()
    {
        Toggle t = _toGJob.GetFirstActiveToggle();
        return t.GetComponentInChildren<Text>().text;
    }
}
