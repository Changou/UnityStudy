using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAddress : MonoBehaviour
{
    [Header("주소록 추가")]
    [SerializeField] InputField _inputName;
    [SerializeField] Toggle[] _toggleMarry;
    [SerializeField] Dropdown[] _drop;
    [SerializeField] Slider _sliderAge;
    [SerializeField] ToggleGroup _toGJob;

    private void OnEnable()
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

        Central._Inst.AddCallArchive(name, marry, county, city, age, job);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }

    string ToggleSelect()
    {
        Toggle t = _toGJob.GetFirstActiveToggle();
        return t.GetComponentInChildren<Text>().text;
    }
}
