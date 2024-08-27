using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddressList : MonoBehaviour
{
    [SerializeField] Dropdown _addressName;
    [SerializeField] TextSetting _addressText;
    [SerializeField] GameObject _removeBtn;
    [SerializeField] GameObject _removeAllBtn;

    public int AddressNameValue { get { return _addressName.value; } }

    bool _isNull = false;

    protected virtual void Awake()
    {
        _addressName.onValueChanged.AddListener(delegate
        {
            SettingText();
        });
    }

    protected virtual void OnEnable()
    {
        _addressName.ClearOptions();

        int cnt = Central._Inst.ListCount();

        if (cnt <= 0)
        {
            _addressName.options.Add(new Dropdown.OptionData("------"));
            _isNull = true;
        }
        else
        {
            _isNull = false;
            for(int i = 0; i < cnt; i++)
            {
                _addressName.options.Add(
                    new Dropdown.OptionData(Central._Inst.GetAddressName(i)));
            }
        }

        _addressName.value = 0;
        _addressName.RefreshShownValue();
        SettingText();
    }

    void SettingText()
    {
        if (_addressText == null) return;
        if (_isNull)
        {
            _removeBtn.SetActive(false);
            _removeAllBtn.SetActive(false);
            _addressText.SettingText();
            return;
        }

        _removeBtn.SetActive(true);
        _removeAllBtn.SetActive(true);

        string[] data = new string[Central._Inst.CallAddressFieldCnt()];
        Central._Inst.GetData(ref data, _addressName.value);
        _addressText.SettingText(data);
    }
}
