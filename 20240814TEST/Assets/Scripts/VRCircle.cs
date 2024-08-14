using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCircle : MonoBehaviour
{
    [SerializeField] Image _circleImg;

    [SerializeField] float _ReticleTime = 1.5f;

    [SerializeField] Transform _pickPosition;

    Camera _cam;

    [SerializeField] GvrReticlePointer _gvrReticlePt;
    public Transform _PickPoint => _pickPosition;

    public PickableItem _myPick;

    float _curTime = 0f;
    float _ReticleTimeNow = 0f;
    float _reticleDist;


    bool _isReticleOn = false;

    RaycastHit _hit;
    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _reticleDist = _gvrReticlePt.maxReticleDistance;
    }

    public void SetReticle_On(bool isOn)
    {
        _isReticleOn = isOn;
    }

    public void ResetReticle()
    {
        _isReticleOn = false;
        _curTime = 0f;
        _ReticleTimeNow = 0f;
    }

    private void Update()
    {
        if (GameManager._Inst._isGameOver) return;

        if (_isReticleOn)
        {
            _curTime += Time.deltaTime;
            _ReticleTimeNow = _curTime / _ReticleTime;
        }

        _circleImg.fillAmount = _ReticleTimeNow;

        Ray ray = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        
        if (Physics.Raycast(ray, out _hit, _reticleDist))
        {
            if (_ReticleTimeNow >= 1f)
            {
                IInterect interect = _hit.transform.GetComponent<IInterect>();

                if (interect != null)
                {
                    interect.Do_interect(transform);
                }

                ResetReticle();
            }
        }

        if(_myPick != null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _myPick.transform.SetParent(null);
                _myPick._rb.isKinematic = false;
                _myPick._coll.enabled = true;
                _myPick._rb.AddForce((_cam.transform.forward + _cam.transform.up) * 2f, ForceMode.Impulse);
                _myPick = null;
            }
        }
    }
}
