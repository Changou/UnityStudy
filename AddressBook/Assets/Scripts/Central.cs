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

    //value�� ����Ʈ ���� call
    public void CallEditAddress(int value, AddressClass newclass)
    {
        _archive.ListEdit(value, newclass);
    }

    //value�� ����Ʈ ���� call
    public void CallRemoveAddress(int value)
    {
        _archive.ListRemove(value);
    }

    //value�� �´� �̸� �ּҷϿ��� �˻�
    public string GetAddressName(int value)
    {
        return _archive.GetAddressName(value);
    }

    //�ּҷ��� �ʵ� ����
    public int CallAddressFieldCnt()
    {
        return _archive.AddressFieldCnt();
    }

    //�̸� �ߺ� üũ
    public bool CheckName(string name)
    {
        if (_archive.IsCheckName(name)) return true;
        return false;
    }

    //value�� �ش��ϴ� ����Ÿ ������
    public void GetData(ref string[] data, int value)
    {
        _archive.GetList(ref data, value);
    }

    //����Ʈ ����
    public int ListCount()
    {
        return _archive.ListCount();
    }

    //���õ����� ������
    public string[] GetCityData(int value)
    {          
        return _archive.GetCityData(value);
    }

    //�ּ� ���
    public void AddCallArchive(AddressClass newAddress)
    {
        _archive.AddNewAddress(newAddress);
    }
}
