using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accession : MonoBehaviour
{
    [Header("회원가입")]
    [SerializeField] InputField[] _inputField;
    [SerializeField] float _delay;
    [SerializeField] Text _unCorrect;
    [SerializeField] GameObject[] _error;
    [SerializeField] GameObject _accession;

    [Header("아이디 중복 확인")]
    [SerializeField] GameObject _dupleBtn;
    [SerializeField] GameObject _dupsuccess;


    enum ERROR
    {
        DUPLICATIONID,
        UNDUPLICATIONPW,
        NOTFULLINPUT,
        NOTDUPLICATION,

        MAX
    }

    bool _isCorrect = false;
    bool _isduplecation = false;

    private void OnEnable()
    {
        _dupleBtn.SetActive(true);
        _dupsuccess.SetActive(false);
        _isduplecation = false;
        transform.GetChild(0).gameObject.SetActive(true);
        foreach(InputField input in _inputField)
        {
            input.text = "";
        }
        foreach(GameObject error in _error)
        {
            error.SetActive(false);
        }
    }

    private void Update()
    {
        string pw = _inputField[2].text;
        string rPw = _inputField[4].text;
        if (!pw.Equals(rPw))
        {
            _isCorrect = false;
            _unCorrect.color = Color.red;
            _unCorrect.text = "불일치";
            _unCorrect.gameObject.SetActive(true);
        }
        else
        {
            _isCorrect = true;
            _unCorrect.color = Color.green;
            _unCorrect.text = "일치";
            _unCorrect.gameObject.SetActive(true);
        }
    }

    public void DuplicationID()
    {
        if (Central._Inst.SearchID(_inputField[1].text))
        {
            StartCoroutine(Error(_error[(int)ERROR.DUPLICATIONID]));
        }
        else
        {
            _isduplecation = true;
            _dupleBtn.SetActive(false);
            _dupsuccess.SetActive(true);
        }
    }

    public void AccessBtn()
    {
        if (_isCorrect)
        {
            string[] _info = new string[_inputField.Length];

            for (int i = 0; i < _inputField.Length - 1; i++)
            {
                if (_inputField[i].text.Equals(""))
                {
                    StartCoroutine(Error(_error[(int)ERROR.NOTFULLINPUT]));
                    return;
                }
                _info[i] = _inputField[i].text;
            }
            if (!_isduplecation)
            {
                StartCoroutine(Error(_error[(int)ERROR.NOTDUPLICATION]));
                return;
            }
            
            Central._Inst.ArchiveAccession(_info);  

            StartCoroutine(Success());
        }
        else
        {
            StartCoroutine(Error(_error[(int)ERROR.UNDUPLICATIONPW]));
        }    
    }

    IEnumerator Error(GameObject error)
    {
        error.SetActive(true);
        yield return new WaitForSeconds(1);
        error.SetActive(false);
    }

    IEnumerator Success()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        _accession.SetActive(true);
        yield return new WaitForSeconds(_delay);
        _accession.SetActive(false);
        UIManager._Inst.Show_Only(UIManager.UI.LOGIN);
    }
}
