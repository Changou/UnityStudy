using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    [SerializeField] float _Power = 0;
    [SerializeField] Vector3 offset;

    [SerializeField] bool isMove = false;
    bool isCameraFollow = false;

    [SerializeField] Vector3 currentV;
    [SerializeField] Vector3 driverDir;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        driverDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            currentV = Input.mousePosition;

            //GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //tmp.transform.position = currentV;
        }
        if (Input.GetMouseButton(0) && !isMove)
        {
            Vector3 point = Input.mousePosition;
            

            _Power = Vector3.Distance(point, currentV);
            
            driverDir = new Vector3(point.x - currentV.x, 0, point.y - currentV.y);
            Debug.Log(driverDir.normalized);
        }
        if (Input.GetMouseButtonUp(0))
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
            Camera.main.transform.position = transform.position + offset;
        }
    }

    void CameraSetting()
    {

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
                isCameraFollow = false;
                Debug.Log("¸ØÃã");
            }
        }
    }

    void Cancel()
    {
        _Power = 0;
    }

    void DriverShot()
    {
        
        rb.AddForce(driverDir.normalized * _Power);
        isCameraFollow = true;
        Cancel();
        StartCoroutine(StopBallCheck());
    }
}
