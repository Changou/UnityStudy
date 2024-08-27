using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Central : MonoBehaviour
{
    public static Central _Inst;

    Archive _archive;

    public string _path;

    private void Awake()
    {
        _Inst = this;
        _archive = new Archive();
        _archive.LoadCityDataFromJson();
    }
    private void Start()
    {
        _path = Application.dataPath;
        _path = _path.Replace("/Assets", "");
        _path = Path.Combine(_path, "Data/AddressData.json");
        _archive.JsonLoad(_path);
    }

    public bool CheckName(string name)
    {
        if (_archive.IsCheckName(name)) return false;
        return true;
    }

    public void GetData(ref string[] data, int value)
    {
        _archive.GetList(ref data, value);
    }

    public int ListCount()
    {
        return _archive.ListCount();
    }

    public string[] GetCityData(int value)
    {          
        return _archive.GetCityData(value);
    }

    public void AddCallArchive(string name, bool marry, string county, string city, int age, string job)
    {
        _archive.AddNewAddress(name, marry, county, city, age, job);
    }
}
