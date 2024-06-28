using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    string _name;
    public string _Name => _name;
    [SerializeField]
    int _lv;
    public int _Lv => _lv;
    [SerializeField]
    int _hp;
    public int _Hp => _hp;
    [SerializeField]
    int _attack;
    public int _Attack => _attack;


    [SerializeField]
    TextMeshPro _tmpHp;

    public void SetData(string name, int lv, int hp, int attack)
    {
        _name = name;
        _lv = lv;
        _hp = hp;
        _attack = attack;

        _tmpHp.text = hp.ToString();
    }

    public abstract void Motion();
}
