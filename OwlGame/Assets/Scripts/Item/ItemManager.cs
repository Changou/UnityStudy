using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager i;

    [Header("[ 아이템 레벨 ]")]
    [SerializeField] int[] _item_LV;

    [Header("[ 아이템 효과 ]")]
    [SerializeField] int _coinEffect = 0;
    [SerializeField] int _jumpEffect = 0;
    [SerializeField] int _movingEffect = 0;
    [SerializeField] int _shotEffect = 0;
    [SerializeField] float _sjumpEffect = 2;
    [SerializeField] float _invEffect = 3;
    [SerializeField] float _feverEffect = 3;

    public int[] _Item_LV => _item_LV;

    public int _CoinEffect => 1 * _coinEffect;
    public int _JumpEffect => 1 * _jumpEffect;
    public int _MovingEffect => 1 * _movingEffect;
    public int _ShotEffect => 1 * _shotEffect;
    public float _SjumpEffect => _sjumpEffect;
    public float _InvEffect => _invEffect;
    public float _FeverEffect => _feverEffect;

    private void Awake()
    {
        i = this;
        _item_LV = new int[(int)ITEM_TYPE.MAX];
        for(int i = 0; i < (int)ITEM_TYPE.MAX; i++)
        {
            _item_LV[i] = 1;
        }
    }

    public void LEVELUP(int i)
    {
        if (_item_LV[i] == 5) return;

        _item_LV[i]++;
    }

    public void FeverUp()
    {
        _feverEffect += 0.1f;
    }

    public void InvUp()
    {
        _invEffect += 0.1f;
    }

    public void SjumpUp()
    {
        _sjumpEffect += 0.1f;
    }

    public void ShotUp()
    {
        ++_shotEffect;
    }

    public void MovingUp()
    {
        ++_movingEffect;
    }

    public void JumpUp()
    {
        ++_jumpEffect;
    }

    public void CoinUp()
    {
        ++_coinEffect;
    }
}
