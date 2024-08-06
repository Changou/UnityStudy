using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //	���� ���¸� ǥ��..
    public enum eSTATE
    {
        Ready,      //	�߻� �غ�..
        Empty,      //	źâ ����..
        Reloading   //	������ ��..

    }//	public enum eSTATE

    //	���� ���� ����..
    public eSTATE _eCurState { get; protected set; }
    //----------------------------
    //	ź���� �߻�� ��ġ..
    public Transform _fireTransf;
    //----------------------------
    //	�ѱ� ȭ�� ����Ʈ..
    public ParticleSystem _muzzleFlashEffect;
    //	ź�� ���� ����Ʈ..
    //public ParticleSystem _shellEjectEffect;
    //----------------------------
    //	ź�� ������ ���� ������..
    LineRenderer _bulletLineRenderer;
    //----------------------------
    //	���� �Ҹ� �����..
    protected AudioSource _gunAudioPlayer;
    //	�߻� �Ҹ�..
    public AudioClip _shotClip;
    //	������ �Ҹ�..
    public AudioClip _reloadClip;
    //----------------------------
    //	���ݷ�..
    public float _damage = 25f;
    //	�����Ÿ�..
    float _fireDist = 50;
    //----------------------------
    //	��ü ź��..
    public int _ammoRemain = 100;
    //	źâ �뷮..
    public int _magCapacity = 25;
    //	���� źâ�� �����ִ� ź��..
    public int _magAmmo;
    //----------------------------
    //	ź�� �߻� ����..
    public float _timeBetFire = 0.12f;
    //	������ �ҿ� �ð�..
    public float _reloadTime = 1.8f;
    //	���� ���������� �߻��� ����..
    float _lastFireTime;
    //----------------------------
    protected virtual void Awake()
    {
        _gunAudioPlayer = GetComponent<AudioSource>();
        _bulletLineRenderer = GetComponent<LineRenderer>();

        _bulletLineRenderer.positionCount = 2;

        _bulletLineRenderer.enabled = false;
    }
    private void OnEnable()
    {
        //	���� źâ ���� ä���..
        _magAmmo = _magCapacity;

        //	���� ���¸� [ �߻� �غ� ] ���·� ��ȯ..
        _eCurState = eSTATE.Ready;

        //	���������� ���� �� ���� �ʱ�ȭ..
        _lastFireTime = 0f;
    }

    public void Fire()
    {
        if (_eCurState == eSTATE.Ready &&                   //	�߻� ��� ���� && 
            Time.time >= _lastFireTime + _timeBetFire)      //	������ �߻� �������� timeBetFire �̻��� �ð��� �������� üũ..
        {
            _lastFireTime = Time.time;
            Shot();
        }
    }

    protected virtual void Shot()
    {
        RaycastHit hit;

        Vector3 hitPos = Vector3.zero;

        if (Physics.Raycast(_fireTransf.position, _fireTransf.forward, out hit, _fireDist))
        {
            //	�浹 ���� OK !!!!!

            //	�浹�� ������Ʈ�κ���
            //	IDamageable ���� �õ�..
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            //	�浹�� ������Ʈ��
            //	IDamageable �� �����ϰ� �ִٸ�
            //	���ݿ� ���� ������ ó����
            //	�� �� �ִ� ������Ʈ��� �ǹ�..
            if (target != null)
            {
                //	������ �����ϱ�..
                target.OnDamage(_damage, hit.point, hit.normal);
            }

            //	���̰� �浹�� ��ġ ����..
            hitPos = hit.point;

        }//	if( Physics.Raycast( _fireTransf.position, _fireTransf.forward, out hit, _fireDist ))
        else
        {
            //	�浹 ���� ���� �Ф�..

            //	ź���� �ִ� �����Ÿ�������
            //	��ġ�� �浹��ġ�� ���.
            hitPos = _fireTransf.position + _fireTransf.forward * _fireDist;

        }//	~if( Physics.Raycast( _fireTransf.position, _fireTransf.forward, out hit, _fireDist ))

        //	�߻� ����Ʈ ���..
        StartCoroutine(ShotEffect(hitPos));

        //	���� ź�� �� ����..
        --_magAmmo;

        //	ź���� ���ٸ�
        //	���� ���¸� Empty�� ����..
        if (_magAmmo <= 0)
            _eCurState = eSTATE.Empty;
    }

    IEnumerator ShotEffect(Vector3 hitPos)
    {
        _muzzleFlashEffect.Play();
        //_shellEjectEffect.Play();
        _gunAudioPlayer.PlayOneShot(_shotClip);

        //	���� ������ ���� ���� ����..
        _bulletLineRenderer.SetPosition(0, _fireTransf.position);

        //	���� ������ ������ ���� ����..
        _bulletLineRenderer.SetPosition(1, hitPos);

        //	���� �������� Ȱ��ȭ�Ͽ� ź�� ���� �׸���..
        _bulletLineRenderer.enabled = true;

        //	0.03�� ���..
        yield return new WaitForSeconds(0.03f);

        //	���� �������� ��Ȱ��ȭ�Ͽ� ź�� ���� �����..
        _bulletLineRenderer.enabled = false;
    }
    public virtual bool Reload()
    {
        //	������ ���̰ų�
        //	���� ź�� ���ų�
        //	źâ�� ź���� ������ ���..
        if (_eCurState == eSTATE.Reloading ||
            _ammoRemain <= 0 ||
            _magAmmo >= _magCapacity)
            return false;

        //	������ ����..
        StartCoroutine(ReloadRoutine());
        return true;
    }
    protected virtual IEnumerator ReloadRoutine()
    {
        //	���� ���¸� [ ������ �� ] ���·� ��ȯ..
        _eCurState = eSTATE.Reloading;

        //	������ �Ҹ� ����..
        _gunAudioPlayer.PlayOneShot(_reloadClip);

        //	������ �ҿ� �ð���ŭ ���..
        yield return new WaitForSeconds(_reloadTime);

        //	źâ�� ä�� ź�˼� ���..
        int ammoToFill = _magCapacity - _magAmmo;

        //	źâ�� ä������ ź�˼���
        //	���� ź�� ������ ���ٸ�
        //	���� ź�˼��� ����..
        if (_ammoRemain < ammoToFill)
            ammoToFill = _ammoRemain;

        //	źâ ä���..
        _magAmmo += ammoToFill;

        //	���� ź�˼� ����..
        _ammoRemain -= ammoToFill;

        //	���� ���¸� [ �߻� �غ� ] ���·� ��ȯ..
        _eCurState = eSTATE.Ready;
    }
}
