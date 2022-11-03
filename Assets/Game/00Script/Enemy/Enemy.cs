using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour, IfieldObject
{


    protected float speed;
    protected int hp;
    protected int point;
    protected float delayMissile;
    private SpriteRenderer spriteRender;
    protected virtual void Awake()
    {
      
    }



    protected virtual void Start()
    {
        TurnAround();
       
    }
    protected virtual void Update() 
    {
        MoveToPlayer();
    }

    protected virtual void init()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();

    }
    private void TurnAround()
    {
        float distanceX =  transform.position.x - Utils.playerPos.position.x;
        if( distanceX >= 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    protected virtual void MoveToPlayer()
    {

        float distanceTime = speed * (Vector3.Distance(transform.position,Utils.playerPos.position));
        transform.position = Vector3.MoveTowards(transform.position, Utils.playerPos.position, speed * Time.deltaTime);
        /* transform?.DOMove(Utils.playerPos.transform.position, distanceTime);*/
    }

    protected virtual void Attack() { }
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            spriteRender.color = Color.yellow;
            
        }else if(collision.gameObject.tag == "PlayerBullet")
        {
            hp--;
            
            spriteRender.color = Color.black;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            hp--;

            spriteRender.color = Color.black;
        }
    }
    protected virtual void OnMouseDown()
    {
        ScoreDelegate scoreDelegate;
        scoreDelegate = new ScoreDelegate(ScoreManager.Inst.PlusScore);
        scoreDelegate(point);
        /*   ScoreManager.Instance.PlusScore(point);*/
        ChangeSpriteRenderer(spriteRender, Color.black);
        hp--;
        if (hp <= 0)
        {
            killEnemyDelegate killEnemyDelegate;
            killEnemyDelegate = new killEnemyDelegate(SpawnManager.Instance.RecieveEnemyKill);
            killEnemyDelegate(1);
            SpawnManager.Instance.enemyOnField.Remove(gameObject);
            Destroy(gameObject);
        }
       

    }
    protected virtual void OnMouseUp()
    {
        ChangeSpriteRenderer(spriteRender, Color.white);
    }

    #region IfieldObject
    public void ChangeSpriteRenderer(SpriteRenderer spriteRenderer, Color color)
    {
       
            spriteRenderer.color = color;
       
    }



    #endregion

   
}
