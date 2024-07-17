using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    protected static GameManager _inst;
    //----------------------------
    [Header("[ ���� ����Ʈ ]"), SerializeField]
    Transform _spawnPt;
    //----------------------------    
    [Header("[ �������� ������ ]"), SerializeField]
    Branch _prefabBranch;
    //----------------------------
    [Header("[ ���� ������ ]"), SerializeField]
    Bird _prefabBird;
    //----------------------------
    [Header("[ ���� ������ ]"), SerializeField]
    Gift _prefabGift;
    //----------------------------
    //  BGM �� ���� ���� ����..
    protected AudioSource _audioSrc;
    //----------------------------
    Vector3 _worldSize;     //  ȭ�� ũ��..( ���� ��ǥ )
    //----------------------------
    protected virtual void Awake()
    {
        _inst = this;
        InitData();
    }
    //----------------------------
    protected virtual void Update()
    {
        Make_Branch();
        Make_Bird();
        Make_Gift();
    }
    //----------------------------
    void InitData()
    {
        //  ����� �ҽ� ����..
        _audioSrc = GetComponent<AudioSource>();

        //  ����� �÷���..
        _audioSrc.loop = true;
        if (_audioSrc.clip != null)
            _audioSrc.Play();

        //  ��ũ�� ��ǥ..
        //  ->  ���� ��ǥ..
        Vector3 scrSize = new Vector3(Screen.width, Screen.height);

        //  ���� ��ǥ�� ����Ϸ���
        //  ī�޶�� ������ ���� ��..
        //  -   �Ÿ��� �ٸ� ����..
        scrSize.z = 10;
        _worldSize = Camera.main.ScreenToWorldPoint(scrSize);

    }// void InitData()
    //----------------------------
    //  �������� �����..
    void Make_Branch()
    {
        //  ���� ������ ����������
        //  ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Branch").Length;

        //  ȭ�鿡 �ִ� ����������
        //  ������ 3���� �ʰ��ϸ�
        //  ���� ���..
        if (cnt > 3)
            return;

        //  ���� ���� ���̿�
        //  ������׷� ��ġ..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);

        //  �������� ����..
        GameObject branch = Instantiate(_prefabBranch.gameObject);
        branch.transform.position = pos;

        //  ���� ���� ��ġ ����..
        _spawnPt.position += new Vector3(0, 3, 0);

    }// void Make_Branch()
    //----------------------------
    void Make_Bird()
    {
        //  ���� ������ ������
        //  ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Bird").Length;

        //  ȭ�鿡 ������ ������
        //  7���� �ʰ��ϸ�
        //  ���� ���..
        if (cnt > 7)
            return;

        //  Ȯ���� 90% �̸��� ���
        //  ���..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  ���� ��ġ ����..
        Vector3 pos = _spawnPt.position;
        pos.y -= Random.Range(0, 5f);

        GameObject bird = Instantiate(_prefabBird.gameObject);
        bird.transform.position = pos;

    }// void Make_Bird()
    //----------------------------
    void Make_Gift()
    {
        //  ������ ���� ���� ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Gift").Length;

        //  ������ ȭ�鿡 3�� �̻��̸�
        //  ���..
        if (cnt >= 3)
            return;

        //  Ȯ���� 90% �̸��� ���
        //  ���..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  ��ġ ����..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);
        pos.y += Random.Range(0.5f, 1.5f);

        //  �̸� ����..
        GameObject gift = Instantiate(_prefabGift.gameObject);
        gift.name = "Gift " + Random.Range(0, 3);
        gift.transform.position = pos;
    }
}
