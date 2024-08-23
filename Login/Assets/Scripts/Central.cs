using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Central : MonoBehaviour
{
    public static Central _Inst;

    Archive _archive;

    public string _path;

    private void Awake()
    {
        _Inst = this;
        _archive = new Archive();
    }

    private void Start()
    {
        _path = Application.dataPath;
        _path = _path.Replace("/Assets", "");
        _path = Path.Combine(_path, "Data/ListData.json");
        _archive.JsonLoad(_path);
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

    public bool SearchID(string id)
    {
        return _archive.SearchDuplicationID(id);
    }

    public string SearchIDInArchive(string name, string adress)
    {
        string searchId = _archive.SearchID(name, adress);
        if (searchId != null) 
        {
            return searchId;
        }
        else return null;
    }

    public string SearchPWInArchive(string id, string name)
    {
        string searchId = _archive.SearchPW(id, name);
        if (searchId != null)
        {
            return searchId;
        }
        else return null;
    }
}
