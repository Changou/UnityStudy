using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertSort : MonoBehaviour
{
    [SerializeField] GameObject[] monster;

    public GameObject[] _Monster => monster;

    void Swap(ref GameObject a, ref GameObject b)
    {
        GameObject tmp = a;
        a = b;
        b = tmp;
    }

    public void Sort(ref int[] array)
    {
        for(int idx = 1;idx < array.Length; ++idx) 
        {
            for(int subIdx = idx -1; subIdx >= 0; --subIdx)
            {
                if (array[subIdx] > array[subIdx + 1])
                {
                    Swap(ref monster[subIdx], ref monster[subIdx + 1]);
                    int a = array[subIdx];
                    array[subIdx] = array[subIdx + 1];
                    array[subIdx + 1] = a;
                }
                else break;
            }
        }
    }
}
