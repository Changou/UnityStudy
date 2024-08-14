using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFootHold : MonoBehaviour
{
    [SerializeField] WayPoints _way;
    [SerializeField] int _nextIndex;

    [SerializeField] float _speed;
    [SerializeField] float _delay = 2f;

    bool _isDelay = false;

    // Update is called once per frame
    void Update()
    {
        if (_isDelay) return;

        Move();
    }

    void Move() 
    {
        Vector3 dir = _way._wayPoints[_nextIndex].position - transform.position;

        transform.Translate(dir.normalized * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoints"))
        {
            _nextIndex = (++_nextIndex >= _way._wayPoints.Length) ? 1 : _nextIndex;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        _isDelay = true;
        yield return new WaitForSeconds(_delay);
        _isDelay = false;
    }
}
