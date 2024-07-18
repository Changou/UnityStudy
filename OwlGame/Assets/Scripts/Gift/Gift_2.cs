using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift_2 : Gift,ICollision
{
    [Header("����"), SerializeField]
    int _score = 100;

    [Header("���ھ� ������"), SerializeField]
    ScoreText _prefabScoreText;
    //------------------------
    public virtual void OnCollide(Vector3 hitPos)
    {
        _audioSource.volume = 0.3f;
        _audioSource.Play();

        GameObject scoreGObj = Instantiate(_prefabScoreText.gameObject);
        scoreGObj.transform.position = hitPos;

        ScoreText scoreText = scoreGObj.GetComponent<ScoreText>();
        scoreText.SetScore(_score * (_idx + 1));

        Destroy(_collider2D);
        Destroy(gameObject, 0.1f);

    }
}
