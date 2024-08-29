using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class AddressClass
{
    public string _name;
    public bool _marry;
    public string _county;
    public string _city;
    public int _age;
    public string _job;

    public AddressClass(string name, bool marry, string county, string city, int age, string job)
    {
        _name = name;
        _marry = marry;
        _county = county;
        _city = city;
        _age = age;
        _job = job;
    }
}

public class Archive
{
    List<AddressClass> _addressList = new List<AddressClass>();

    public void JsonFileSave(string path, AddressClass editAddress)
    {
        JsonUtilityExtention.FileSave(editAddress, path);
    }

    //value���� ����Ʈ ����
    public void ListEdit(int value, AddressClass newclass)
    {
        _addressList.RemoveAt(value);
        _addressList.Insert(value, newclass);
        JsonSave();
    }

    //����Ʈ ��ü ����
    public void ListRemoveAll()
    {
        _addressList.Clear();
        JsonSave();
    }

    //value���� ����Ʈ ����
    public void ListRemove(int value)
    {
        _addressList.RemoveAt(value);
        JsonSave();
    }

    //value���� �̸� ������
    public string GetAddressName(int value)
    {
        return _addressList[value]._name;
    }

    //�ּҷ� �ʵ� ����
    public int AddressFieldCnt()
    {
        var field = typeof(AddressClass).GetFields();
        return field.Count();
    }

    //�̸� �ߺ� üũ
    public bool IsCheckName(string name)
    {
        int index = _addressList.FindIndex(x => x._name.Equals(name));
        if (index != -1) return true;
        else return false;
    } 
    
    //value���� ������ ������
    public void GetList(ref string[] data, int value)
    {
        data[0] = _addressList[value]._name;
        if (_addressList[value]._marry)
            data[1] = "��ȥ";
        else
            data[1] = "��ȥ";
        data[2] = _addressList[value]._county;
        data[3] = _addressList[value]._city;
        data[4] = _addressList[value]._age.ToString();
        data[5] = _addressList[value]._job;
    }

    //�ּҷ� ����Ʈ ��
    public int ListCount()
    {
        return _addressList.Count;
    }

    public void JsonLoadFile(ref string[] data, string path)
    {
        AddressClass newAddress = JsonUtilityExtention.FileLoad<AddressClass>(path);
        data[0] = newAddress._name;
        if (newAddress._marry)
            data[1] = "��ȥ";
        else
            data[1] = "��ȥ";
        data[2] = newAddress._county;
        data[3] = newAddress._city;
        data[4] = newAddress._age.ToString();
        data[5] = newAddress._job;
    }

    //json �ε�
    public void JsonLoad(string path)
    {
        if(!File.Exists(path))
        {
            return;
        }
        else
        {
            _addressList = JsonUtilityExtention.FileLoadList<AddressClass>(path);
        }
    }

    //json ���̺�
    public void JsonSave()
    {
        JsonUtilityExtention.FileSaveList(_addressList, Central._Inst._path);
    }

    //�� �ּҷ� ���
    public void AddNewAddress(AddressClass newclass)
    {
        _addressList.Add(newclass);
        JsonSave();
    }

    [Serializable]
    public class City
    {
        public string[] city;
    }

    List<City> _cityList = new List<City>();

    public void LoadCityDataFromJson()
    {
        string path = Application.dataPath;
        path = path.Replace("/Assets", "");
        path = Path.Combine(path, "Data/CityData.json");
        _cityList = JsonUtilityExtention.FileLoadList<City>(path);
    }

    //value���� �������� ������
    public string[] GetCityData(int value)
    {
       
        string[] data = new string[_cityList[value].city.Length];
        for(int i = 0; i<data.Length; i++)
        {
            data[i] = _cityList[value].city[i];
        }

        return data;
    }
}
