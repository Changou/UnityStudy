using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,ICollision
{
    Collider2D _collider2D;

    [Header("����"), SerializeField]
    int _score = 100;

    [Header("���ھ� ������"), SerializeField]
    ScoreText _prefabScoreText;

    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        if (pos.y < -30f)
            Destroy(gameObject);
    }

    public void OnCollide(Vector3 hitPos)
    {
        GameObject scoreGObj = Instantiate(_prefabScoreText.gameObject);
        scoreGObj.transform.position = hitPos;

        ScoreText scoreText = scoreGObj.GetComponent<ScoreText>();
        scoreText.SetScore(_score);

        Destroy(_collider2D);
        Destroy(gameObject, 0.1f);

        GameManager_2._Inst.Get_Coin();
    }

    void InitData()
    {
        _collider2D = GetComponent<Collider2D>();
    }

}
