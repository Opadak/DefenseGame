using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Singleton<Player>,IfieldObject
{
 
    private Castle castle;

    private  int level;
    private  int hp;
    private  int maxHP;
    public int Hp { get;  set; }

    public int MaxHp { get; set; }
    public  int Level { get;  set; }

    private Sprite castleSprite;
    private SpriteRenderer playerRenderer;
    private List<Castle> UiCastleList ;
    static float damageTime = 0.05f;
    private StatusType status;
    private StatusType statusType;


    private void Start()
    {
        statusType = StatusType.VERY_GOOD;
        Init();
      
    }
    private void Init()
    {
       
        UiCastleList = UIManager.Instance.myCastle;
        playerRenderer = GetComponent<SpriteRenderer>();
    }
   
    public void Setup(Castle castle)
    {
        this.castle = castle;
        level = castle.level;
        MaxHp = castle.hp;
        Hp = castle.hp;
        castleSprite = castle.castleSprite;
        Level = level;
    }
    private void ControlLevel()
    {
        level++;
        if(level >= UiCastleList.Count-1)
        {
            level = UiCastleList.Count-1;
            return;
        }

        UIManager.Instance.LevelUp(level);
    }
    

    #region IfieldObject
    public void ChangeSpriteRenderer(SpriteRenderer spriteRenderer, Color color)
    {

        spriteRenderer.color = color;

    }
    public void InvokeChangeSpriteRender()
    {
        ChangeSpriteRenderer(playerRenderer, Color.white);
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyMissile"|| collision.gameObject.tag == "BossMissile")
        {

            Hp = Hp - 1;
            if (Hp <= 0 &&UIManager.Instance._hp >0)
                return;
            status = CheckHpState();
            if(statusType != status)
            {
                statusType = status;
                StatusEventManager.Instance.DispatchEvent(this, status);
            }
          
            ChangeSpriteRenderer(playerRenderer, Color.red);
            Invoke("InvokeChangeSpriteRender", damageTime);
        }
       
    }

    public StatusType CheckHpState()
    {
        MaxHp = UIManager.Instance.myCastleMaxHp[level];
        if (Hp >= MaxHp * 0.8f)
        {        
            return StatusType.VERY_GOOD;
        } else if (Hp >= MaxHp * 0.6f)
        {      
            return StatusType.GOOD;
        }
        else if (Hp >= MaxHp * 0.4f)
        {     
            return StatusType.BAD;
        }
        else if (Hp >= 0)
        { 
            return StatusType.VERY_BAD;
        }
        else
        {
        
            return StatusType.DEAD;
        }

    }

   

    public void UpgradeBtn()
    {
        ControlLevel();
    }


    public void ShieldBtn()
    {
       /* shieldPrefab.SetActive(true);*/
    }

}
