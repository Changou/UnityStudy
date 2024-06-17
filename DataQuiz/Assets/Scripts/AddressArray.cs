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
        //  예외처리..
        if (_arr == null) return;

        if (insertIdx < 0) return;

        //  원본크기 + 1 인 임시 배열 생성..
        T[] tmp = new T[_arr.Length + 1];

        //  삽입하려는 인덱스가
        //  원본 크기 이상인 경우엔
        //  마지막 요소 다음에 추가..
        if (insertIdx >= _arr.Length) { Add(val); return; }

        //  삽입하려는 인덱스에 데이터 입력..
        tmp[insertIdx] = val;

        //  나머지 인덱스 정렬..
        for (int cur = 0; cur < insertIdx; ++cur)
            tmp[cur] = _arr[cur];
        for (int cur = insertIdx + 1; cur < tmp.Length; ++cur)
            tmp[cur] = _arr[cur - 1];

        _arr = tmp;

    }
    public void Remove(int removeIdx)
    {
        //  예외처리..
        if (removeIdx < 0 ||
            _arr.Length <= removeIdx)
            return;

        //  원본크기 - 1 인 임시 배열 생성..
        T[] tmp = new T[_arr.Length - 1];

        int resIdx = 0;
        for (int cur = 0; cur < _arr.Length; ++cur)
        {
            //  제거하려는 인덱스와
            //  동일한 인덱스는 
            //  임시 배열에
            //  포함하지 않음..
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
