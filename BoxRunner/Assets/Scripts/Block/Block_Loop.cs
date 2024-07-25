using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Loop : MonoBehaviour
{
    [Header("�̵� �ӵ�"), SerializeField]
    public float _speed = 3f;

    [Header("������ ���"), SerializeField]
    GameObject[] _blockPrefabs;

    [Header("��� ���"), SerializeField]
    GameObject _a_Zone;

    [Header("ȭ�� ������ ���"), SerializeField]
    GameObject _b_Zone;

    private void Awake() { Time.timeScale = 1f; }

    void Update() { Move(); }

    [Header("����� ����")]
    [SerializeField] int _difficult = 2;

    public void LevelUp()
    {
        ++_difficult;
        if(_difficult > _blockPrefabs.Length)
            _difficult = _blockPrefabs.Length;
    }

    void Make()
    {
        int blockIdx = Random.Range(0, _difficult);

        _b_Zone = Instantiate(
            _blockPrefabs[blockIdx],
            /*  �ణ�� ƴ�� �߻�!!!
            //  -   [ _b_Zone ]�� x ����
            //      ��Ȯ�� 0�� �Ǵ� ������ �ƴ�
            //      0 ������ ��쿡 �����ϱ� ����..
            //      -   [ Time.deltaTime ]�� ����
            //          ��� ȯ���̳� ��Ȳ�� ����
            //          �̹��ϰ� �ٸ��� ����..
            new Vector3(30, -5, 0),
            //*/

            //*  �ַ��..
            new Vector3(_a_Zone.transform.position.x + 30, -5, 0),
            //*/
            Quaternion.identity);
    }
    void Move()
    {
        _a_Zone.transform.Translate(Vector3.left * _speed * Time.deltaTime);
        _b_Zone.transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (_b_Zone.transform.position.x <= 0f)
        {
            //  �տ� �ִ� ��� ����..
            Destroy(_a_Zone);

            //  ���� ����� ����..
            _a_Zone = _b_Zone;

            //  �� ��� �����..
            Make();

        }// if (_b_Zone.transform.position.x <= 0f)

    }
}
