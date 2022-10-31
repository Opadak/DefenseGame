using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour,IfieldObject
{

    private Castle castle;

    private int level;
    private int hp;
    public int Hp { get;  set; }
    public int Level { get;  set; }

    private Sprite castleSprite;
    private SpriteRenderer playerRenderer;
    private List<Castle> UiCastleList ;
   
    static float damageTime = 0.05f;
    enum CastleState : int
    {
        VERY_GOOD,
        GOOD,
        NOT_BAD,
        BAD
    }
    private void Start()
    {
        Init();
      
    }
    private void Init()
    {
       
        UiCastleList = UIManager.Inst.myCastle;
        playerRenderer = GetComponent<SpriteRenderer>();
    }
   
    public void Setup(Castle castle)
    {
        this.castle = castle;
        level = castle.level;
        hp = castle.hp;
        castleSprite = castle.castleSprite;
        Hp = hp;
        Level = level;
    }
    private void ControlLevel()
    {
        level++;
        if(level >= UiCastleList.Count-1)
        {
            level = UiCastleList.Count-1;
        }

        UIManager.Inst.LevelUp(level);
    }
    public void Btn()
    {
        ControlLevel();
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

            Hp--;
            ChangeSpriteRenderer(playerRenderer, Color.red);
            Invoke("InvokeChangeSpriteRender", damageTime);
        }
       
    }



   
}
