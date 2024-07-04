using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    [SerializeField] float _Power = 0;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] Text _StatusT;
    [SerializeField] Text _Count;
    [SerializeField] GameObject overT;

    [Header("카메라"), SerializeField] GameObject _Camera;

    [SerializeField] bool isMove = false;
    bool isCameraFollow;
    bool isGreen = false;
    bool isGameOver = false;

    [SerializeField] Vector3 currentV;
    [SerializeField] Vector3 driverDir;
    Rigidbody rb;

    string currentG;

    int parCount = 4;
    int maxCount = 6;
    [SerializeField] int driveCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        driverDir = Vector3.zero;
        isCameraFollow = true;
        _StatusT.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMove && !isGameOver)
        {
            currentV = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && !isMove)
        {
            Vector3 point = Input.mousePosition;
            

            _Power = Vector3.Distance(point, currentV);

            driverDir = new Vector3(point.x - currentV.x, 0, point.y - currentV.y);
        }
        if (Input.GetMouseButtonUp(0) && !isMove && !isGameOver)
        {
            if(_Power > 100)
            {
                isMove = true;
                DriverShot();
            }
            else Cancel();
        }
        if (isCameraFollow)
        {
            _Camera.transform.position = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Green"))
        {
            isGreen = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        currentG = collision.gameObject.tag;
    }

    void CameraSetting()
    {
        Vector3 dir = target.transform.position - _Camera.transform.position;
        _Camera.transform.rotation = Quaternion.LookRotation(dir).normalized;
    }

    IEnumerator StopBallCheck()
    {
        while (isMove)
        {
            Vector3 tmp = transform.position;
            yield return new WaitForSeconds(0.1f);
            if ((transform.position - tmp).magnitude < 0.05f)
            {
                rb.isKinematic = true;
                rb.isKinematic = false;
                isMove = false;
                transform.LookAt(target);
                CameraSetting();
                if (currentG.Equals("Hall") || driveCnt == maxCount)
                {
                    GameClear();
                }
                else
                    StartCoroutine(TextOn());
            }
        }
    }

    void GameClear()
    {
        isGameOver = true;
        overT.SetActive(true);
        switch(parCount - driveCnt)
        {
            case 0:
                overT.transform.GetChild(1).GetComponent<Text>().text = "파";
                break;
            case 1:
                overT.transform.GetChild(1).GetComponent<Text>().text = "버디";
                break;
            case 2:
                overT.transform.GetChild(1).GetComponent<Text>().text = "이글";
                break;
            case 3:
                overT.transform.GetChild(1).GetComponent<Text>().text = "홀인원";
                break;
            case -1:
                overT.transform.GetChild(1).GetComponent<Text>().text = "보기";
                break;
            default:
                overT.transform.GetChild(1).GetComponent<Text>().text = "더블보기";
                break;
        }
    }

    IEnumerator TextOn()
    {
        _StatusT.gameObject.SetActive(true);
        _StatusT.text = $"지형은 {currentG}, 남은거리는 {Vector3.Distance(transform.position, target.position)}m";
        yield return new WaitForSeconds(2f);
        _StatusT.gameObject.SetActive(false);
    }

    void Cancel()
    {
        _Power = 0;
    }

    void DriverShot()
    {
        driveCnt++;
        _Count.text = "친 횟수 : " + driveCnt;

        rb.AddRelativeForce((driverDir.normalized + new Vector3(0, isGreen? 0 : 1f, 0)) * (_Power * 2f));

        Cancel();
        StartCoroutine(StopBallCheck());
    }
}
