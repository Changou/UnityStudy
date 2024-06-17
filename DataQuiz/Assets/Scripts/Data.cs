using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public struct Data 
{
    public string _name;
    int _age;
    string _address;
    string _phone;

    public Data(string name , int age , string address, string phone)
    {
        _name = name;
        _age = age;
        _address = address;
        _phone = phone;
    }

    public bool SearchData(int idx, string val)
    {
        if ((idx == 0 && _name.Equals(val)) || (idx == 2 && _address.Equals(val)))
            return true;
        else
            return false;
    }

    public override string ToString()
    {
        return $"�̸� : {_name}\n���� : {_age}\n�ּ� : {_address}\n��ȭ��ȣ : {_phone}";
    }
}
