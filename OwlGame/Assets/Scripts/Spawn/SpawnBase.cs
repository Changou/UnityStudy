using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBase : MonoBehaviour
{
    [Header("[ ���� ����Ʈ ]"), SerializeField]
    protected Transform _spawnPt;

    protected Vector3 _worldSize;

    private void Awake()
    {
        InitData();
    }

    private void Update()
    {
        Make();
    }

    void InitData()
    {
        Vector3 scrSize = new Vector3(Screen.width, Screen.height);

        //  ���� ��ǥ�� ����Ϸ���
        //  ī�޶�� ������ ���� ��..
        //  -   �Ÿ��� �ٸ� ����..
        scrSize.z = 10;
        _worldSize = Camera.main.ScreenToWorldPoint(scrSize);
    }

    protected virtual void Make() { }
}
