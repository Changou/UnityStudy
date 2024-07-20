using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    protected Animator _anim;
    protected AudioSource _audioSource;
    protected Rigidbody2D _rb2D;
    protected Collider2D _collider2D;

    int _dir;
    [Header("[ 이동 속도 ]"), SerializeField]
    protected float _speed = 5f;

    [Header("올빼미"), SerializeField] protected Owl_6 _Owl;

    void InitBird()
    {
        _dir = (Random.Range(0, 2) == 0) ? -1 : 1;
        transform.localScale = new Vector3(_dir, 1, 1);

        _speed = Random.Range(5f, 8f);

        _anim.speed = 1 + (_speed - 5) / 3;

        Vector3 worldPos = transform.position;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        if (_dir == -1)
            screenPos.x = Screen.width + 50;
        else
            screenPos.x = -50f;

        screenPos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rb2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _Owl = GameObject.Find("Owl").GetComponent<Owl_6>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitBird();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager_2._Inst._IsPause) return;

        float amount = _speed * _dir * Time.deltaTime;
        transform.Translate(Vector3.right * amount);

        CheckAlive();
    }

    void CheckAlive()
    {
        Vector3 worldPos = transform.position;

        worldPos.z = 10f;

        Vector2 pos = Camera.main.WorldToScreenPoint(worldPos);

        if ((pos.y < -30) ||
            (_dir == -1 && pos.x < -30) ||
            (_dir == 1 && pos.x > Screen.width + 30))
            Destroy(gameObject);
    }
}
