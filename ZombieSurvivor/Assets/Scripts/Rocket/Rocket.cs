using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField] float _speed = 5f;
    [SerializeField] ParticleSystem _particleFire;
    [SerializeField] GameObject _explotion;
    [SerializeField] RPG _rpg;
    [SerializeField] SphereCollider _coll;

    private void Awake()
    {
        _coll = GetComponent<SphereCollider>();
        GetComponent<Rocket>().enabled = false;
        _coll.enabled = false;
    }

    public void GetRPG()
    {
        _rpg = GetComponentInParent<RPG>();
    }

    private void OnEnable()
    {
        transform.SetParent(null);
        _coll.enabled = true;
        _particleFire.Play();
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.localPosition += transform.TransformDirection(-Vector3.forward) * _speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        if(target != null )
        {
            _explotion.SetActive(true);
            _explotion.transform.SetParent(null);
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
    public void Damage(IDamageable target, Vector3 other)
    {
        Vector3 normal = other - transform.position;
        target.OnDamage(_rpg._damage, other, normal.normalized);
    }
}
