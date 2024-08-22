using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour
{
    public static Central _Inst;

    Archive _archive;

    private void Awake()
    {
        _Inst = this;
        _archive = new Archive();
    }

    public void ArchiveAccession(string[] info)
    {
        _archive.AddNewInfomation(info);
    }

    public string LoginArchive(string id, string pw)
    {
        string searchName = _archive.Search(id, pw);
        if (searchName != null)
            return searchName;
        else return null;
    }
}
