using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{

    [SerializeField]
    private Player player;
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private TextMeshPro StageTxt;
    [SerializeField]
    private TextMeshPro LevelTxt;
    [SerializeField]
    private TextMeshPro HpTxt;
    [SerializeField]
    private TextMeshPro MyStatusTxt;
    [SerializeField]
    private CastleSO castleSO;
    [SerializeField]
    public GameObject clearPanel;
    [SerializeField]
    public GameObject gameOverPanel;
    [SerializeField]
    public GameObject playingPanel;
    public List<Castle> myCastle;
    public List<int> myCastleMaxHp;
    static float damageTime = 0.05f;
    private Coroutine checkPlayerStatCo = null; // level, hp 가 update되는 것을 체크 해주는 코루틴
    public int _hp;                                     

    private StatusType statusType;


    void Start()
    {
       
        StatusEventManager.Instance.SendEvent += StatusEventManager_SendEvent;
        SetupCastleStat();
        SetUpLevelUp(0);
        checkPlayerStatCo = StartCoroutine(checkPlayerStat());

    }

 

    private void SetUpLevelUp(int level)
    {
        LevelTxt.text = "Level " + myCastle[level].level;
        HpTxt.text = "Hp " + myCastle[level].hp;
        playerSprite.sprite = myCastle[level].castleSprite;
        player.Level = myCastle[level].level;
        player.Hp = myCastle[level].hp;
        StatusEventManager.Instance.DispatchEvent(this, StatusType.VERY_GOOD);
    }

    public void LevelUp(int level)
    {
        player.Setup(myCastle[level]);
        UIManager.Instance.SetUpLevelUp(level);
    }
    private void SetupCastleStat()
    {
        myCastle = new List<Castle>();
        for (int i = 0; i < castleSO.castles.Length; i++)
        {
            Castle castle = castleSO.castles[i];
            myCastle.Add(castle);
            myCastleMaxHp.Add(castle.hp);
        }

    }

    IEnumerator checkPlayerStat()
    { 
        int _level = player.Level;
        _hp = player.Hp;
        while (true)
        {
            if (_level != player.Level)
            {
                _level = player.Level;
               
                ChangeUiText(LevelTxt, _level);
            }
            else if (_hp != player.Hp)
            {
              
                _hp = player.Hp;
                ChangeUiText(HpTxt, _hp);
            }
            yield return new WaitForSeconds(damageTime);
        }
    }

    private void ReceivePlayerStatus(StatusType statusType)
    {
        ChangeUiText(MyStatusTxt, statusType);
    
        switch (statusType)
        {
            case StatusType.VERY_GOOD:
                Camera.main.backgroundColor = Color.white;
                MyStatusTxt.GetComponent<TextMeshPro>().color = Color.red;
                break;
            case StatusType.GOOD:
              
                break;
            case StatusType.BAD:
                Camera.main.backgroundColor = Color.yellow;
                break;
            case StatusType.VERY_BAD:
                Camera.main.backgroundColor = Color.red;
                MyStatusTxt.GetComponent<TextMeshPro>().color = Color.black;
                break;
            case StatusType.DEAD:
                Camera.main.backgroundColor = Color.black;
                MyStatusTxt.GetComponent<TextMeshPro>().color = Color.white;
                GameManager.Instance.GameOver(true);
                //게임 오버 
                break;

        }
    }

    private void ChangeUiText( TextMeshPro textMesh, object result )
    {
        textMesh.text = textMesh.name + " " + result;
    }
    private void ChangeUiText( TextMeshPro textMesh, StatusType result)
    {
        textMesh.text = result.ToString();
    }
    protected override void OnDestroy()
    {
        if (checkPlayerStatCo != null)
        {
            StopCoroutine(checkPlayerStatCo);
            checkPlayerStatCo = null;
        }
     /*   StatusEventManager.Instance.SendEvent -= StatusEventManager_SendEvent;*/
        
    }

    private void StatusEventManager_SendEvent(StatusType obj, EventArgs e)
    {
        ReceivePlayerStatus(obj);

        Debug.Log(e.GetType());


    }
    public void NextStage()
    {
        clearPanel.SetActive(false);
        StageManager.Instance.StartStage();
        ChangeUiText(StageTxt,StageManager.Instance.Stage);
    }
}
