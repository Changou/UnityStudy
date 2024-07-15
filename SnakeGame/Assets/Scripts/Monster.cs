using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour, ICollide
{
    [Header("[ ∏ÛΩ∫≈Õ ]")]
    [SerializeField] float _speedMove;
    [SerializeField] float _rotSpeed;

    [Header("[ ≈∏∞Ÿ ]"), SerializeField] Transform _target;

    NavMeshAgent nav;

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
        nav = GetComponent<NavMeshAgent>();
        _DefaultColor = transform.GetComponent<Renderer>().material.color;
        if (StageManager.i._CurrentStage == 3)
            nav.speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.gameObject.GetComponent<Snake>()._IsDead)
        {
            nav.isStopped = true;
            return;
        }

        if (_Freezing) return;

        AIMonster();

        //MoveMonster();
    }

    void AIMonster()
    {
        nav.SetDestination(_target.position);
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
        nav.isStopped = true;
        yield return new WaitForSeconds(time);
        _Freezing = false;
        transform.GetComponent<Renderer>().material.color = _DefaultColor;
        nav.isStopped = false;
        _FreezeCor = null;
    }

    //void MoveMonster()
    //{
    //    float amount = _speedMove * Time.deltaTime;
    //    transform.Translate(Vector3.forward * amount);

    //    Vector3 dir = _target.position - transform.position;
    //    transform.rotation = Quaternion.Lerp(transform.rotation, 
    //        Quaternion.LookRotation(dir), _rotSpeed * Time.deltaTime);
    //}

    public void Collide(Snake snake) 
    {
        if (snake._IsPower)
            Destroy(gameObject);
        else
            snake.Dead(); 
    }
}
