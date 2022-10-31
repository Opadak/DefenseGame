using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Inst { get; set; }
    void Awake() => Inst = this;

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
    private CastleSO castleSO;

    public List<Castle> myCastle;
    static float damageTime = 0.05f;
    private Coroutine checkPlayerStatCo = null; // level, hp 가 update되는 것을 체크 해주는 함수 
    void Start()
    {

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
    }

    public void LevelUp(int level)
    {
        player.Setup(myCastle[level]);
        UIManager.Inst.SetUpLevelUp(level);
    }
    private void SetupCastleStat()
    {
        myCastle = new List<Castle>();
        for (int i = 0; i < castleSO.castles.Length; i++)
        {
            Castle castle = castleSO.castles[i];
            myCastle.Add(castle);
        }

    }


    IEnumerator checkPlayerStat()
    { 
        int _level = player.Level;
        int _hp = player.Hp;
        while (true)
        {
            if (_level != player.Level)
            {
                _level = player.Level;
               
                ChangeUiText( ref LevelTxt, _level);
            }
            else if (_hp != player.Hp)
            {
              
                _hp = player.Hp;
                ChangeUiText(ref HpTxt, _hp);
            }
            yield return new WaitForSeconds(damageTime);
        }
    }


 
    private void ChangeUiText(ref TextMeshPro textMesh, int result )
    {
        textMesh.text = textMesh.name + result;
    }
    private void OnDestroy()
    {
        if (checkPlayerStatCo != null)
        {
            StopCoroutine(checkPlayerStatCo);
            checkPlayerStatCo = null;
        }

    }
}
