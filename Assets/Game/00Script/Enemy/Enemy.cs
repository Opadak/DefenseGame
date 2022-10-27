using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
 
    [SerializeField]
    private float speed;
    [SerializeField]
    private int hp;

    protected virtual void Start()
    {
        TurnAround();
        MoveToPlayer();
    }
    protected virtual void Update() { }


    protected void TurnAround()
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
    protected void MoveToPlayer()
    {

        float distanceTime = speed * (Vector3.Distance(transform.position,Utils.playerPos.position));
        transform.DOMove(Utils.playerPos.transform.position, distanceTime);
    }

    protected virtual void Attack() { }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
            mesh.color = Color.red;
            
        }
    }

    protected virtual void OnMouseDown()
    {
        SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
        mesh.color = Color.black;
        DOTween.Kill(transform);
        Destroy(gameObject);

        //Enemy를 클릭해 잡을 시 GameManager "OnDisplayScore"메소드 사용하여 점수를 업해주기 
    }
    protected virtual void OnMouseUp()
    {

    }
}
