using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_2 : GameManager
{
    public static GameManager_2 _Inst => _inst as GameManager_2;
    //----------------------------
    [Header("[ UI 매니저 ]"), SerializeField]
    UIManager _uiManager;
    public UIManager _UIManager => _uiManager;
    //----------------------------    
    [Header("[ 모바일 플랫폼 플래그 ]"), SerializeField]
    bool _isMobile = false;
    public bool _IsMobile => _isMobile;

    // 게임 정지
    bool _isPause = false;

    public bool _IsPause => _isPause ;

    //  게임 오버??
    bool _isGameOver = false;

    // 코인 획득 수..
    int _coinCount = 0;

    // 코인 획득 점수..
    int _coinScore = 0;

    //  선물 획득 수..
    int _giftCount = 0;

    //  선물 획득 점수..
    int _giftScore = 0;

    //  참새 충돌 횟수..
    int _birdCount = 0;

    //  총 점수..
    int _score = 0;

    //  올빼미 높이..
    float _owlHeight = 0f;

    // 올빼미 레벨
    int _owlLevel = 1;

    [SerializeField] int _test = 1;

    //----------------------------
    //  [ Force To Mono ]
    //  -   최적화를 위해 Mono로 수정..
    [Header("[ 메인 bgm ]"), SerializeField]
    AudioClip _bgmMain;

    [Header("[ 게임 오버 bgm ]"), SerializeField]
    AudioClip _bgmGameOver;
    //----------------------------
    [Header("[ 올빼미 ]"), SerializeField]
    Owl _myOwl;
    //----------------------------
    protected override void Awake()
    {
        base.Awake();

        //  커서 숨기기..
        Cursor.visible = false;

        //  bgm 연출..
        Play_AudioClip(
            _bgmMain,
            true);

        //  게임 정보 UI..
        _uiManager.Show_Panel_Only(UIManager.ePANEL.INFO);

        //  모바일 플랫폼 확인..
        /*
        _isMobile = ( Application.platform == RuntimePlatform.Android ||
                      Application.platform == RuntimePlatform.IPhonePlayer );
        //*/

        //  모바일인 경우에만 버튼 노출..
        if (_isMobile)
            _uiManager.Show_Panel_With(UIManager.ePANEL.INPUT);

    }// protected override void Awake()
    //----------------------------
    public void Play_AudioClip(AudioClip clip, bool isLoop, float volume = 0.3f)
    {
        _audioSrc.clip = clip;
        _audioSrc.loop = isLoop;
        _audioSrc.volume = volume;
        _audioSrc.Play();
    }
    //----------------------------
    void Update()
    {
        if (!_isGameOver)
            Update_Score();
    }
    //----------------------------
    void Update_Score()
    {
        if (_myOwl.transform.position.y > _owlHeight)
            _owlHeight = _myOwl.transform.position.y;

        if ((int)((_owlHeight / _test) + 1) > _owlLevel)
        {
            ++_owlLevel;
            _uiManager.Show_Panel_With(UIManager.ePANEL.ENFORCE);
            Pause();
        }
        _score
            = Mathf.FloorToInt(_owlHeight)
                * 100
                + _giftScore
                + _coinScore
                - _birdCount * 100;

        _uiManager.Set_Height(_owlHeight);

        _uiManager.Set_Gift(_giftCount);

        _uiManager.Set_Bird(_birdCount);

        _uiManager.Set_Score(_score);

        _uiManager.Set_Coin(_coinCount);

        _uiManager.Set_Level(_owlLevel);

    }// void Update_Score()
    //----------------------------
    public void Get_Coin()
    {
        _coinCount += 1 + ItemManager.i._CoinEffect;

        _coinScore += 100 * ItemManager.i._CoinEffect;
    }

    public void Get_Gift(int giftType)
    {
        ++_giftCount;

        _giftScore += (giftType * 100) + 100;

    }// public void Get_Gift( int giftType )
    //----------------------------
    public void BirdStrike()
    {
        ++_birdCount;
    }
    //----------------------------
    public void Set_GameOver()
    {
        _isGameOver = true;

        _uiManager.Show_Panel_Only(UIManager.ePANEL.GAMEOVER);

        Cursor.visible = true;

        //  bgm 연출..
        Play_AudioClip(
            _bgmGameOver,
            false);
    }

    public void UnPause()
    {
        _isPause = false;
    }

    public void Pause()
    {
        _isPause = true;
    }
}
