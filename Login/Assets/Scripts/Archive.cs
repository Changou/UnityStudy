using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archive
{
    public class Infomation
    {
        string _name;
        string _id;
        string _password;
        string _address;

        public string _ID => _id;
        public string _Password => _password; 

        public Infomation(string name, string id, string password, string address)
        {
            _name = name;
            _id = id;
            _password = password;
            _address = address;
        }
    }

    List<Infomation> _InfoArchive = new List<Infomation>();

    public string Search(string id, string pw)
    {
        int index = _InfoArchive.FindIndex(x => x._ID.Equals(id));
        if (index == -1)  return null; 
        if (_InfoArchive[index]._Password.Equals(pw)) return null;

        return _InfoArchive[index]._ID;
    }

    public void AddNewInfomation(string[] info)
    {
         Infomation newInfo = new Infomation(info[0], info[1], info[2], info[3]);
        _InfoArchive.Add(newInfo);
    }
}
