using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum Type
{
    PATROL,
    TRACKING,
    ATTACK
}

public class Move : MonoBehaviour
{
    [Header("����")]
    [SerializeField] Type _t = Type.PATROL;

    [Header("��Ʈ�� �þ߰�")]
    [SerializeField] float _viewAngle = 30f;
    [SerializeField] float _radius = 5f;

    [Header("Ÿ��")]
    [SerializeField] Transform _target;

    [Header("�Ѿ�")]
    [SerializeField] GameObject bulletprefab;

    [Header("������ �Ÿ�")]
    [SerializeField] float rayMaxDistance = 6f;

    [Header("ȸ�� �ӵ�")]
    [SerializeField] float rotSpeed = 3;

    [Header("�� ����")]
    [SerializeField] Transform _wall;

    [Header("����ǥ��")]
    [SerializeField] Text stateText;

    Renderer patrolColor;

    [SerializeField] float speed = 15f;
    float currentSpeed;
    float decelerationRate = 0.992f;
    float trackingSpeed = 3f;
    float bulletSpeed = 10f;
    bool _isCoroutine = false;
    float rotateDirection = 0;
    int _isDirection = 0;

    void Start()
    {
        patrolColor = gameObject.GetComponent<Renderer>();
        currentSpeed = speed;
    }

    void Update()
    {
        PatrolMachine();
        stateText.text = gameObject.name + " : " + _t.ToString();
        if (_t == Type.PATROL)
        {
            if (currentSpeed > 0.01f)
            {
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
                currentSpeed *= decelerationRate;
            }
            else
            {
                rotateDirection = Random.Range(3, 8f) * 10;
                _isDirection = Random.Range(1, 11);
                if (_isDirection%2 == 0)
                {
                    rotateDirection *= -1;
                }
                transform.Rotate(0, rotateDirection, 0);
                currentSpeed = Random.Range(8,15);
            }
        }
        else if( _t == Type.TRACKING || _t == Type.ATTACK) 
        {
            Vector3 dir = _target.position - transform.position;
            dir.Normalize();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * trackingSpeed * Time.deltaTime); 
        }
    }


    IEnumerator Shot()
    {
        Debug.Log(gameObject.name + " ���ݸ�� ON");
        _isCoroutine = true;
        GameObject bullet = Instantiate(bulletprefab, transform.position + transform.forward, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed,ForceMode.Impulse);
        yield return new WaitForSeconds(1.5f);
        _isCoroutine = false;
        Destroy(bullet, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Vector3 dir = Vector3.zero - transform.position;
            transform.rotation = Quaternion.LookRotation(dir).normalized;
            currentSpeed = 10f;
        }
    }

    void PatrolMachine()
    {
        Vector3 leftDir, rightDir;
        leftDir = GetVectorWithAngle(_viewAngle * 0.5f, _radius);
        rightDir = GetVectorWithAngle(-_viewAngle * 0.5f, _radius);

        Debug.DrawLine(transform.position, transform.position + leftDir, Color.green);
        Debug.DrawLine(transform.position, transform.position + rightDir, Color.green);
        Debug.DrawLine(transform.position, transform.position + transform.forward * rayMaxDistance, Color.white);

        if (IsTargetInSight(_target, _radius))
        {
            
            if( Vector3.Distance(transform.position, _target.position) < 3f)
            {
                patrolColor.material.color = Color.red;
                _t = Type.ATTACK;
                if (!_isCoroutine)
                { 
                    StartCoroutine(Shot());
                }
            }
            else
            {
                patrolColor.material.color = Color.yellow;
                //Debug.Log("������� ON");
                _t = Type.TRACKING;
            }
        }
        else
        {
            patrolColor.material.color = Color.blue;
            //Debug.Log("������� ON");
            _t = Type.PATROL;
        }
    }

    Vector3 GetVectorWithAngle(float angle, float radius)
    {
        float theta = angle - transform.eulerAngles.y + 90;
        Vector3 dir = new Vector3(
            Mathf.Cos(theta * Mathf.Deg2Rad),
            0,
            Mathf.Sin(theta * Mathf.Deg2Rad))
            * radius;

        return dir;
    }
    bool IsTargetInSight(Transform target, float viewDist)
    {
        Vector3 targetDir = (target.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, targetDir);

        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        float dist = Vector3.SqrMagnitude(transform.position - target.position);
        if (viewDist * viewDist >= dist && theta <= _viewAngle * 0.5f)
            return true;

        return false;
    }
}
