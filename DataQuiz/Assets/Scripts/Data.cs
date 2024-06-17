using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public struct Data 
{
    string _name;
    int _age;
    string _address;
    string _phone;

    public Data(string name, int age, string address, string phone)
    {
        _name = name;
        _age = age;
        _address = address;
        _phone = phone;
    }

    public override string ToString()
    {
        return $"{_name},{_age},{_address},{_phone}";
    }
}
