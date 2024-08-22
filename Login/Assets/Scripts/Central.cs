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

    public string SearchInArchive(string id, string pw)
    {
        string searchId = _archive.Search(id, pw);
        if (searchId != null)
            return searchId;
        else return null;
    }
}
