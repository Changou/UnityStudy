using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public struct Data 
{
    public string _name;
    public int _age;
    public string _address;
    public string _phone;

    public Data(string name , int age , string address, string phone)
    {
        _name = name;
        _age = age;
        _address = address;
        _phone = phone;
    }

    public override string ToString()
    {
        return $"�̸� : {_name}\n���� : {_age}\n�ּ� : {_address}\n��ȭ��ȣ : {_phone}";
    }
}
