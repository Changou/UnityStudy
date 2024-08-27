using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public class Archive
{
    [Serializable]
    public class Address
    {
        public string _name;
        public bool _marry;
        public string _county;
        public string _city;
        public int _age;
        public string _job;

        public Address(string name, bool marry, string county, string city, int age, string job)
        {
            _name = name;
            _marry = marry;
            _county = county;
            _city = city;
            _age = age;
            _job = job;
        }
    }

    List<Address> _addressList = new List<Address>();

    public bool IsCheckName(string name)
    {
        int index = _addressList.FindIndex(x => x._name.Equals(name));
        if (index != -1) return true;
        else return false;
    } 

    public void GetList(ref string[] data, int value)
    {
        data[0] = _addressList[value]._name;
        if (_addressList[value]._marry)
            data[1] = "±‚»•";
        else
            data[1] = "πÃ»•";
        data[2] = _addressList[value]._county;
        data[3] = _addressList[value]._city;
        data[4] = _addressList[value]._age.ToString();
        data[5] = _addressList[value]._job;
    }

    public int ListCount()
    {
        return _addressList.Count;
    }

    public void JsonLoad(string path)
    {
        if(!File.Exists(path))
        {
            return;
        }
        else
        {
            _addressList = JsonUtilityExtention.FileLoadList<Address>(path);
        }
    }

    public void JsonSave()
    {
        JsonUtilityExtention.FileSaveList(_addressList, Central._Inst._path);
    }

    public void AddNewAddress(string name, bool marry, string county, string city, int age, string job)
    {
        Address newInfo = new Address(name, marry, county, city, age, job);
        _addressList.Add(newInfo);
        JsonSave();
    }

    [Serializable]
    public class City
    {
        public string city1;
        public string city2;
        public string city3;
        public string city4;

        public string City1 { get { return city1; } }
        public string City2 { get { return city2; } }
        public string City3 { get { return city3; } }
        public string City4 { get { return city4; } }
    }

    List<City> _cityList = new List<City>();

    public void LoadCityDataFromJson()
    {
        string path = Application.dataPath;
        path = path.Replace("/Assets", "");
        path = Path.Combine(path, "Data/CityData.json");
        _cityList = JsonUtilityExtention.FileLoadList<City>(path);
    }

    public string[] GetCityData(int value)
    {
        var props = typeof(City).GetProperties();
        string[] data = new string[props.Count()];
        data[0] = _cityList[value].City1;
        data[1] = _cityList[value].City2;
        data[2] = _cityList[value].City3;
        data[3] = _cityList[value].City4;
        return data;
    }
}
