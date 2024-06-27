using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sphere : MonoBehaviour
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
    TextMeshPro _tmpName;
    [SerializeField]
    TextMeshPro _tmpLv;
    [SerializeField]
    TextMeshPro _tmpHp;
    [SerializeField]
    TextMeshPro _tmpAttack;

    public void SetData(string name, int lv, int hp, int attack)
    {
        _name = name;
        _lv = lv;
        _hp = hp;
        _attack = attack;

        _tmpName.text = name;
        _tmpLv.text = lv.ToString();
        _tmpHp.text = hp.ToString();
        _tmpAttack.text = attack.ToString();

    }
}
