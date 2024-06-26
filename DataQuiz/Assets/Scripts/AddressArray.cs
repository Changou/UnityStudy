using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressArray
{
    Data[] _arr;

    public AddressArray(params Data[] args) 
    {
        _arr = new Data[args.Length];

        for (int cur = 0; cur < args.Length; ++cur)
            _arr[cur] = args[cur];
    }

    public string GetData(int index)
    {
        return _arr[index].ToString();
    }

    public int Length()
    {
        return _arr.Length;
    }

    public Data Search(string val)
    { 
        for(int i = 0;i< _arr.Length; i++)
        {
            if (val.Equals(_arr[i]._name) || val.Equals(_arr[i]._address))
            {
                return _arr[i];   
            }
        }
        return new Data();
    }

    public void Add(Data val)
    {
        if (_arr == null)
            _arr = new Data[1];
        else
            Array.Resize<Data>(ref _arr, _arr.Length + 1);

        _arr[_arr.Length - 1] = val;
    }

    public void Edit(Data CurrentVal, Data EditValue)
    {
        //  예외처리..
        if (_arr == null) return;
        
        for(int i = 0;i< _arr.Length; i++)
        {
            if (_arr[i]._name.Equals(CurrentVal._name))
            {
                _arr[i] = EditValue;
            }
        }
    }
    public void Remove(Data CurrentVal)
    {
        Data[] tmp = new Data[_arr.Length - 1];

        int resIdx = 0;
        for (int cur = 0; cur < _arr.Length; ++cur)
        { 
            if (_arr[cur]._name.Equals(CurrentVal._name)) continue;
            tmp[resIdx++] = _arr[cur];
        }
        _arr = tmp;
    }

    public void RemoveAll()
    {
        Data[] tmp = new Data[0];
        _arr = tmp;
    }

    public void ShowInfo()
    {
        string res = "";
        foreach (Data tmp in _arr) res += tmp + "  ";
        Debug.Log(res);

    }

}
