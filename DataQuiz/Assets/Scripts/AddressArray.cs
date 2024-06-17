using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressArray<T>
{
    T[] _arr;

    public AddressArray(params T[] args) 
    {
        _arr = new T[args.Length];

        for (int cur = 0; cur < args.Length; ++cur)
            _arr[cur] = args[cur];
    }
    public void Add(T val)
    {
        if (_arr == null)
            _arr = new T[1];
        else
            Array.Resize<T>(ref _arr, _arr.Length + 1);

        _arr[_arr.Length - 1] = val;

    }
    public void Insert(int insertIdx, T val)
    {
        //  ����ó��..
        if (_arr == null) return;

        if (insertIdx < 0) return;

        //  ����ũ�� + 1 �� �ӽ� �迭 ����..
        T[] tmp = new T[_arr.Length + 1];

        //  �����Ϸ��� �ε�����
        //  ���� ũ�� �̻��� ��쿣
        //  ������ ��� ������ �߰�..
        if (insertIdx >= _arr.Length) { Add(val); return; }

        //  �����Ϸ��� �ε����� ������ �Է�..
        tmp[insertIdx] = val;

        //  ������ �ε��� ����..
        for (int cur = 0; cur < insertIdx; ++cur)
            tmp[cur] = _arr[cur];
        for (int cur = insertIdx + 1; cur < tmp.Length; ++cur)
            tmp[cur] = _arr[cur - 1];

        _arr = tmp;

    }
    public void Remove(int removeIdx)
    {
        //  ����ó��..
        if (removeIdx < 0 ||
            _arr.Length <= removeIdx)
            return;

        //  ����ũ�� - 1 �� �ӽ� �迭 ����..
        T[] tmp = new T[_arr.Length - 1];

        int resIdx = 0;
        for (int cur = 0; cur < _arr.Length; ++cur)
        {
            //  �����Ϸ��� �ε�����
            //  ������ �ε����� 
            //  �ӽ� �迭��
            //  �������� ����..
            if (cur == removeIdx) continue;
            tmp[resIdx++] = _arr[cur];
        }
        _arr = tmp;
    }
    public void ShowInfo()
    {
        string res = "";
        foreach (T tmp in _arr) res += tmp + "  ";
        Debug.Log(res);

    }

}
