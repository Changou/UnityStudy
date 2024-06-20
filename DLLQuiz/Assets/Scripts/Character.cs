using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] string[] _RandomName;

    [SerializeField] TextMeshPro _text;

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
    }

    public string _Name
    {
        get { return _name; }
    }

    
}
