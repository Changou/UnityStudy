using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SKILL
{
    À§,
    ¾Æ·¡,
    ¾Õ,
    µÚ,
    ÆÝÄ¡,
    Å±
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
            Enqueue(SKILL.À§);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Enqueue(SKILL.¾Æ·¡);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Enqueue(SKILL.¾Õ);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Enqueue(SKILL.µÚ);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Enqueue(SKILL.ÆÝÄ¡);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Enqueue(SKILL.Å±);
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
        if (tmp[0].Equals("¾Æ·¡") && tmp[1].Equals("¾Õ") && tmp[2].Equals("ÆÝÄ¡"))
        {
            anim.SetTrigger("IsJangpoong");
            Shoot();
            Debug.Log("ÀåÇ³");
        }
        else if (tmp[0].Equals("¾Æ·¡") && tmp[1].Equals("µÚ") && tmp[2].Equals("Å±"))
        {
            anim.SetTrigger("IsSKick");
            Debug.Log("½´ÆÛÅ±!");
        }
        else if (tmp[0].Equals("µÚ") && tmp[1].Equals("¾Õ") && tmp[2].Equals("ÆÝÄ¡"))
        {
            anim.SetTrigger("IsSPunch");
            Debug.Log("½´ÆÛÆÝÄ¡!");
        }
        else
        {
            if (tmp[0].Equals(SKILL.ÆÝÄ¡.ToString()))
            {
                anim.SetTrigger("IsPunch");
                Debug.Log("ÆÝÄ¡!");
            }
            else if(tmp[0].Equals(SKILL.Å±.ToString()))
            {
                anim.SetTrigger("IsKick");
                Debug.Log("Å±!");
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
