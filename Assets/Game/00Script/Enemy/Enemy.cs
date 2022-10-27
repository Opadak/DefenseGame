using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
 
    [SerializeField]
    private float speed;


    public virtual void Start()
    {
        TurnAround();
        MoveToPlayer();
    }
    public virtual void Update() { }
   
  
    void TurnAround()
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
    void MoveToPlayer()
    {

        float distanceTime = speed * (Vector3.Distance(transform.position,Utils.playerPos.position));
        transform.DOMove(Utils.playerPos.transform.position, distanceTime);
    }
    public virtual void Attack() { }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
            mesh.color = Color.red;
            transform.DOKill();
        }
    }

    void OnMouseDown()
    {
        SpriteRenderer mesh = GetComponentInChildren<SpriteRenderer>();
        mesh.color = Color.black;
        Destroy(gameObject);
    }
}
