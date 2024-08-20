using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CAR_TYPE
{
    RED,
    PURPLE,
    YELLOW,
    BLUE,
    GRAY,

    MAX
}

public class CarMove : MonoBehaviour
{
    [SerializeField] float _maxCarSpeed;
    [SerializeField] float _minCarSpeed;
    [SerializeField] float _carSpeed;
    [SerializeField] CAR_TYPE _type;

    Rigidbody _rb;

    bool _stop = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _rb.isKinematic = false;
        StartCoroutine(ChangeSpeed());
    }

    private void Update()
    {
        if (_stop) return;

        _rb.AddForce(transform.forward * _carSpeed, ForceMode.Force);
    }
    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _carSpeed = Random.Range(_minCarSpeed, _maxCarSpeed);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndLine") && !GameManager2._Inst._carRanks.Contains(_type))
        {
            _stop = true;
            _rb.isKinematic = true;
            GameManager2._Inst._carRanks.Add(_type);
        }
    }
}
