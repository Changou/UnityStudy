using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ICollide
{
    [Header("[ ∏ÛΩ∫≈Õ ]")]
    [SerializeField] float _speedMove;
    [SerializeField] float _rotSpeed;

    [Header("[ ≈∏∞Ÿ ]"), SerializeField] Transform _target;

    Coroutine _FreezeCor;
    Color _DefaultColor;

    bool _Freezing = false;

    // Start is called before the first frame update
    private void Awake()
    {
        _target = GameObject.Find("Snake").transform;
    }

    void Start()
    {
        _DefaultColor = transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(_target.gameObject.GetComponent<Snake>()._IsDead) return;

        if (_Freezing) return;
        
        MoveMonster();
    }

    public void Freeze(float time)
    {
        if (_FreezeCor != null)
            StopCoroutine(FreezeTime(time));

        _FreezeCor = StartCoroutine(FreezeTime(time));
    }

    IEnumerator FreezeTime(float time)
    {
        _Freezing = true;
        transform.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(time);
        _Freezing = false;
        transform.GetComponent<Renderer>().material.color = _DefaultColor;
        _FreezeCor = null;
    }

    void MoveMonster()
    {
        float amount = _speedMove * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);

        Vector3 dir = _target.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(dir), _rotSpeed * Time.deltaTime);
    }

    public void Collide(Snake snake) 
    {
        if (snake._IsPower)
            Destroy(gameObject);
        else
            snake.Dead(); 
    }
}
