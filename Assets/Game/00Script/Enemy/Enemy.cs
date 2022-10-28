using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{


    protected float speed;
    protected int hp;
    protected int point;
    protected float delayMissile;
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
   
    private IEnumerator AttackCo()
    {
        SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
        mesh.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        mesh.color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
            mesh.color = Color.yellow;
            
        }
    }

    protected virtual void OnMouseDown()
    {
        ScoreDelegate scoreDelegate;
        scoreDelegate = new ScoreDelegate(GameManager.Inst.ShowScoreToTextMesh);
        scoreDelegate(point);
        /*GameManager.Inst.ShowScoreToTextMesh(point);*/
        StartCoroutine(AttackCo());
        hp--;
        if (hp <= 0)
            Destroy(gameObject);

    }
    protected virtual void OnMouseUp()
    {
       
    }


}
