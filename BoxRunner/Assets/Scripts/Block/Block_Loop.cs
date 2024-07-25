using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Loop : MonoBehaviour
{
    [Header("이동 속도"), SerializeField]
    public float _speed = 3f;

    [Header("생성할 블록"), SerializeField]
    GameObject[] _blockPrefabs;

    [Header("가운데 블록"), SerializeField]
    GameObject _a_Zone;

    [Header("화면 오른쪽 블록"), SerializeField]
    GameObject _b_Zone;

    private void Awake() { Time.timeScale = 1f; }

    void Update() { Move(); }

    [Header("어려움 정도")]
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
            /*  약간의 틈이 발생!!!
            //  -   [ _b_Zone ]의 x 값이
            //      정확히 0이 되는 순간이 아닌
            //      0 이하인 경우에 생성하기 때문..
            //      -   [ Time.deltaTime ]의 값이
            //          기기 환경이나 상황에 따라
            //          미묘하게 다르기 때문..
            new Vector3(30, -5, 0),
            //*/

            //*  솔루션..
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
            //  앞에 있는 블록 제거..
            Destroy(_a_Zone);

            //  우측 블록을 참조..
            _a_Zone = _b_Zone;

            //  새 블록 만들기..
            Make();

        }// if (_b_Zone.transform.position.x <= 0f)

    }
}
