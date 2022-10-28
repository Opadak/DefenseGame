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
        if(level >= 3)
        {
            level = 3;
        }

        GameManager.Inst.LevelUp(level);
    }
    public void Btn()
    {
        ControlLevel();
    }
}
