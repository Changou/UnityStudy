using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    [SerializeField] GameObject[] preFabs;

    [Header("������ġ")]
    [SerializeField] int min;
    [SerializeField] int max;

    CStack<GameObject> stack;

    int _count = 0;

    private void Start()
    {
        stack = new CStack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newNode = Instantiate(preFabs[Random.Range(0, preFabs.Length)]);
            newNode.transform.position = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
            ++_count;
            newNode.transform.GetChild(0).GetComponent<TextMeshPro>().text = _count.ToString();
            stack.Push(newNode);
        }
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.X))
        {
            if (_count == 0)
            {
                Debug.Log("������Ʈ�� �������� �ʽ��ϴ�.");
            }
            else
            {
                Destroy(stack.Pop());
                --_count;
            }
        }
    }
}
