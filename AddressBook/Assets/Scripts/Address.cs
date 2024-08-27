using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum COUNTY
{
    SEOUL,
    GYEONGGI,
    GANGWON,
    CHUNGCHEONGBUK,
    CHUNGCHEONGNAM,
    GYEONGSANGBUK,
    GYEONGSANGNAM,
    JEOLLABUK,
    JEOLLANAM,

    MAX
}

public class Address : MonoBehaviour
{
    [SerializeField] Dropdown _county;
    [SerializeField] Dropdown _city;

    private void OnEnable()
    {
        _county.value = 0;
        ChangedCity();
    }

    public void ChangedCity()
    {
        _city.ClearOptions();

        string[] data = Central._Inst.GetCityData(_county.value);

        for (int i = 0; i < data.Length; i++)
        {
            _city.options.Add(new Dropdown.OptionData(data[i]));
        }
        _city.value = 0;
        _city.RefreshShownValue();
    }
}
