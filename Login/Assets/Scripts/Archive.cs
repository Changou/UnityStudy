using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using System;

public class Archive
{
    [Serializable]
    public class Infomation
    {
        public string _name;
        public string _id;
        public string _password;
        public string _adress;


        public Infomation(string name, string id, string password, string adress)
        {
            _name = name;
            _id = id;
            _password = password;
            _adress = adress;
        }
    }

    List<Infomation> _InfoArchive = new List<Infomation>();

    public void JsonLoad(string path)
    {
        if (!File.Exists(path))
        {
            string[] newinfo = { "장호연", "123", "123", "서울" };
            AddNewInfomation(newinfo);
        }
        else
        {
            _InfoArchive = JsonUtilityExtention.FileLoadList<Infomation>(path);
        }
    }

    public void JsonSave()
    {
        JsonUtilityExtention.FileSaveList(_InfoArchive, Central._Inst._path);
    }

    public string Search(string id, string pw)
    {
        int index = _InfoArchive.FindIndex(x => x._id.Equals(id));
        if (index == -1)  return null; 
        if (!_InfoArchive[index]._password.Equals(pw)) return null;

        return _InfoArchive[index]._name;
    }

    public bool SearchDuplicationID(string id)
    {
        int index = _InfoArchive.FindIndex(x => x._id.Equals(id));
        if (index != -1)
            return true;
        else return false;
    }

    public string SearchID(string name, string adress)
    {
        int index = _InfoArchive.FindIndex(x => x._name.Equals(name));
        if (index == -1) return null;
        if (!_InfoArchive[index]._adress.Equals(adress)) return null;

        return _InfoArchive[index]._id;
    }

    public string SearchPW(string id, string name)
    {
        int index = _InfoArchive.FindIndex(x => x._id.Equals(id));
        if (index == -1) return null;
        if (!_InfoArchive[index]._name.Equals(name)) return null;

        return _InfoArchive[index]._password;
    }

    public void AddNewInfomation(string[] info)
    {
        Infomation newInfo = new Infomation(info[0], info[1], info[2], info[3]);
        _InfoArchive.Add(newInfo);
        JsonSave();
    }
}
