using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FileSave : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            if (i == 1) transform.GetChild(i).gameObject.SetActive(true);
            else transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SaveFileData()
    {
        if (string.IsNullOrEmpty(Central._Inst._path))
        {
            string path = EditorUtility.SaveFilePanel("주소록 저장", "", "", "json");
            if (string.IsNullOrEmpty(path)) return;

            Central._Inst._path = path;
        }
        Central._Inst.SaveFile();
        UIManager._Inst.Message(UIManager.MESSAGE.SAVE);
        
        gameObject.SetActive(false);
    }

    public void SaveAsFileData()
    {
        string path = EditorUtility.SaveFilePanel("주소록 다른이름으로 저장", "", "", "json");

        if (string.IsNullOrEmpty(path)) return;

        Central._Inst.SaveAsFile(path);
        UIManager._Inst.Message(UIManager.MESSAGE.SAVE);

        gameObject.SetActive(false);
    }
    
}
