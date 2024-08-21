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
    [SerializeField] float _startSpeed;
    [SerializeField] float _prevSpeed;
    [SerializeField] CAR_TYPE _type;

    [Header("부스터 효과"), SerializeField] ParticleSystem _particle;

    Rigidbody _rb;

    bool _stop = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _particle.Play();
        _stop = false;
        _rb.isKinematic = false;
        _carSpeed = _minCarSpeed;

        StartCoroutine(ChangeSpeed());
    }

    private void Update()
    {
        if (_stop) return;

        if(_rb.IsSleeping()) _rb.AddForce(transform.forward * _startSpeed, ForceMode.Impulse);

        //if (_rb.velocity.y != 0) _rb.AddForce(transform.forward * _startSpeed, ForceMode.Impulse);

        _rb.AddForce(transform.forward * _carSpeed, ForceMode.Force);
    }

    IEnumerator ChangeSpeed()
    {
        while (!_stop)
        {
            yield return new WaitForSeconds(1f);
            _carSpeed = Random.Range(_minCarSpeed, _maxCarSpeed);
            if (_carSpeed > _prevSpeed + 300)
                _particle.Play();
            else
                _particle.Stop();

            _prevSpeed = _carSpeed;
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
