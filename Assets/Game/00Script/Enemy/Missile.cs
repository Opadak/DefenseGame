using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Missile : MonoBehaviour
{
    private float dirX;
    private float dirY;

    protected virtual void Start()
    {
      
    
    }

    protected virtual void Update() {

        AttackPlayer();
    }

 
  

    protected virtual void AttackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, Utils.playerPos.position, 3f * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
       
            Destroy(gameObject);
        }
    }
}
