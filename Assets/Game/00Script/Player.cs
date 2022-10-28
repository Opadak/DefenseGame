using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{

    private Castle castle;
    private int level;
    private int hp;
    private Sprite castleSprite;

    enum CastleState : int
    {
        VERY_GOOD,
        GOOD,
        NOT_BAD,
        BAD
    }
    public void Setup(Castle castle)
    {
        this.castle = castle;
        level = castle.level;
        hp = castle.hp;
        castleSprite = castle.castleSprite;
    }
    private void ControlLevel()
    {
        level++;
        if(level >= GameManager.Inst.myCastle.Count-1)
        {
            level = GameManager.Inst.myCastle.Count-1;
        }

        GameManager.Inst.LevelUp(level);
    }
    public void Btn()
    {
        ControlLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp--;
        }
    }

}
