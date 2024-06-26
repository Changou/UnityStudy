using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] string[] _RandomName;

    [SerializeField] TextMeshPro _text;
    [SerializeField] TextMeshPro _Statustext;

    string _name;
    int _hp;
    int _atk;
    int _def;

    private void Awake()
    {
        _name = _RandomName[Random.Range(0, _RandomName.Length)];
        _hp = Random.Range(10, 101);
        _atk = Random.Range(1, 10);
        _def = Random.Range(1, 10);
        _text.text = _name;
        _Statustext.text = ToString();
    }

    public string _Name
    {
        get { return _name; }
    }

    public override string ToString()
    {
        return $"Name : {_name}\nHP : {_hp}\nATK : {_atk}\nDEF : {_def}";
    }
}
