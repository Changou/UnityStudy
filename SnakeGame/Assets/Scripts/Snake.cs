using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float _speedMove = 3f;
    public float _speedRot = 120f;

    protected bool _isDead = false;
    public bool _IsDead => _isDead;

    [Header("[ 部府 祸 ]"), SerializeField]
    Color[] _tailColor;
    [Header("[ 部府 橇府普 ]"), SerializeField]
    GameObject _prefabTail;

    List<Transform> _tails = new List<Transform>();

    protected virtual void InitData() { }

    private void Awake()
    {
        InitData();
    }

    public virtual void AddTail()
    {
        
        GameObject tail = Instantiate(_prefabTail);

        Vector3 pos = transform.position - (transform.forward * 0.15f);

        int tailCount = _tails.Count;

        if(tailCount == 0)
        {
            tail.tag = "Untagged";
            Destroy(tail.GetComponent<SnakeTail>());
            Collider coll = tail.GetComponent<Collider>();
            coll.enabled = false;
            StartCoroutine(CRT_CollideOn(coll));
        }
        else
        {
            pos = _tails[tailCount - 1].position;
        }
        int colorIdx = tailCount / 3 % 2;
        tail.GetComponent<Renderer>().material.color = _tailColor[colorIdx];
        tail.transform.position = pos;
        _tails.Add(tail.transform);
    }

    IEnumerator CRT_CollideOn(Collider coll)
    {
        yield return new WaitForSeconds(0.5f);
        coll.enabled = true;
    }

    void MoveTail()
    {
        Transform target = transform;

        foreach(Transform tail in _tails)
        {
            Vector3 pos = target.position - (target.forward * 0.15f);
            Quaternion rot = target.rotation;

            tail.SetPositionAndRotation(Vector3.Lerp(tail.position,pos,Time.deltaTime * 4),
                Quaternion.Lerp(tail.rotation, rot, Time.deltaTime * 4));
            target = tail;
        }
    }

    protected virtual void MoveHead()
    {
        float amount = _speedMove * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);

        amount = Input.GetAxis("Horizontal") * _speedRot;

        transform.Rotate(Vector3.up * amount * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
            return;

        MoveHead();
        MoveTail();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<ICollide>(out var iTmp))
            return;

        iTmp.Collide(this);
    }
    public virtual void Dead() { }
}
