using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_2 : Bird, ICollision
{
    [Header("패널티 점수"), SerializeField]
    int _penaltyScore = 100;

    [Header("스코어 프리팹"), SerializeField]
    ScoreText _prefabScoreText;

    public virtual void OnCollide(Vector3 hitPos)
    {
        _audioSource.volume = 0.3f;
        _audioSource.Play();

        transform.localEulerAngles = new Vector3(0, 0, 180f);
        _anim.enabled = false;
        Destroy(_collider2D);
        _rb2D.gravityScale = 1f;
        _speed = 0f;

        GameObject scoreGObj = Instantiate(_prefabScoreText.gameObject);
        scoreGObj.transform.position = hitPos;
        ScoreText score = scoreGObj.GetComponent<ScoreText>();
        score.SetScore(_penaltyScore);
    }
}
