using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SKILL
{
    ��,
    �Ʒ�,
    ��,
    ��,
    ��ġ,
    ű
}

public class GameManager : MonoBehaviour
{

    [SerializeField] float delay;
    [SerializeField] GameObject prefabJ;

    CQueue<string> queue = new CQueue<string>();
    Coroutine inputSkill;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Enqueue(SKILL.��);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Enqueue(SKILL.�Ʒ�);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Enqueue(SKILL.��);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Enqueue(SKILL.��);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Enqueue(SKILL.��ġ);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Enqueue(SKILL.ű);
        }
    }

    void Enqueue(SKILL skill)
    {
        string _skill = skill.ToString();
        queue.Enqueue(_skill);
        if(inputSkill == null)
        {
            inputSkill = StartCoroutine(InputDelay());
        }
    }

    IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(delay);
        Activated();
        inputSkill = null;
    }

    void Activated()
    {

        string[] tmp = new string[3];
        int count = 0;
        while (!queue._IsEmpty)
        {
            tmp[count++] = queue.Dequeue();
        }
        if (tmp[0].Equals("�Ʒ�") && tmp[1].Equals("��") && tmp[2].Equals("��ġ"))
        {
            anim.SetTrigger("IsJangpoong");
            Shoot();
            Debug.Log("��ǳ");
        }
        else if (tmp[0].Equals("�Ʒ�") && tmp[1].Equals("��") && tmp[2].Equals("ű"))
        {
            anim.SetTrigger("IsSKick");
            Debug.Log("����ű!");
        }
        else if (tmp[0].Equals("��") && tmp[1].Equals("��") && tmp[2].Equals("��ġ"))
        {
            anim.SetTrigger("IsSPunch");
            Debug.Log("������ġ!");
        }
        else
        {
            if (tmp[0].Equals(SKILL.��ġ.ToString()))
            {
                anim.SetTrigger("IsPunch");
                Debug.Log("��ġ!");
            }
            else if(tmp[0].Equals(SKILL.ű.ToString()))
            {
                anim.SetTrigger("IsKick");
                Debug.Log("ű!");
            }
        }
    }
    void Shoot()
    {
        GameObject jP = Instantiate(prefabJ);
        jP.transform.position = new Vector3(1, 1.3f, 0);
        jP.GetComponent<Rigidbody>().AddForce(new Vector3(1000,0,0));
        Destroy(jP, 2);
    }
}
