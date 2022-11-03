using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : Missile
{
   
    protected override void Start()
    {
        base.Start();
    }

    
    protected override void Update()
    {
        base.Update();
      
    }

    protected override void Attack()
    {
        base.Attack();
        transform.position = Vector3.MoveTowards(transform.position, Utils.playerPos.position, 3f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
        }
    }
}
