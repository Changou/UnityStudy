using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCircle : MonoBehaviour
{
    //----------------------------------
    [Header("[ 레티클에 사용할 이미지 ]"), SerializeField]
    Image _imgCircle;
    protected float _ReticleRate
    {
        get { return _imgCircle.fillAmount; }
        set { _imgCircle.fillAmount = value; }
    }
    //----------------------------------
    [Header("[ 레티클 이벤트 발동 시간 ]"), SerializeField]
    protected float _onReticleTime = 1.5f;

    //  레티클 발동 시간
    //  체크용 타이머 변수..
    protected float _curTime = 0f;
    //----------------------------------
    //  레티클 반응 체크..
    protected bool _isReticleOn = false;
    protected void Reset_Reticle()
    {
        _curTime = 0f;
        _ReticleRate = 0f;
        _isReticleOn = false;
    }
    //----------------------------------
    public void Set_Reticle(bool isOn)
    {
        _isReticleOn = isOn;
        if (isOn == false) Reset_Reticle();
    }
    //----------------------------------
    protected virtual void Update()
    {
        if (_isReticleOn)
        {
            _curTime += Time.deltaTime;
            _ReticleRate = _curTime / _onReticleTime;
        }

    }
}
