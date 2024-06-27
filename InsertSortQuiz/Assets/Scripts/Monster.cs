using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MONSTER_TYPE
{
    CACTUS,
    MUSHROOM,
    SLIME,
    ZOMBIE,
    TURTLE
}

public class Monster : MonoBehaviour
{
    [SerializeField] float monSpeed;
    [SerializeField] MONSTER_TYPE monType;

    Animator anim;

    bool isDie = false;
    public bool isSpeacial = false;

    int point = 1;

    public string _MonType
    {
        get { return monType.ToString(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDie)
            transform.position += transform.forward * monSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            if (!isSpeacial)
            {
                isDie = true;
                anim.SetTrigger("IsDie");
                gameObject.layer = 6;
                GameManager.i.ScoreUp(point);
                GameManager.i.KillCount((int)monType);
            }
            else
            {
                isSpeacial = false;
                point = 2;
            }
                
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    public void Down()
    {
        Destroy(gameObject);
    }
    
}
