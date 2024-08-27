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

        _path = Application.dataPath;
        _path = _path.Replace("/Assets", "");
        _path = Path.Combine(_path, "Data/AddressData.json");
        _archive.JsonLoad(_path);
    }

    public void CallRemoveAllAddress()
    {
        _archive.ListRemoveAll();
    }

    //value번 리스트 편집 call
    public void CallEditAddress(int value, AddressClass newclass)
    {
        _archive.ListEdit(value, newclass);
    }

    //value번 리스트 삭제 call
    public void CallRemoveAddress(int value)
    {
        _archive.ListRemove(value);
    }

    //value에 맞는 이름 주소록에서 검색
    public string GetAddressName(int value)
    {
        return _archive.GetAddressName(value);
    }

    //주소록의 필드 개수
    public int CallAddressFieldCnt()
    {
        return _archive.AddressFieldCnt();
    }

    //이름 중복 체크
    public bool CheckName(string name)
    {
        if (_archive.IsCheckName(name)) return true;
        return false;
    }

    //value에 해당하는 데이타 가져옴
    public void GetData(ref string[] data, int value)
    {
        _archive.GetList(ref data, value);
    }

    //리스트 개수
    public int ListCount()
    {
        return _archive.ListCount();
    }

    //도시데이터 가져옴
    public string[] GetCityData(int value)
    {          
        return _archive.GetCityData(value);
    }

    //주소 등록
    public void AddCallArchive(AddressClass newAddress)
    {
        _archive.AddNewAddress(newAddress);
    }
}
