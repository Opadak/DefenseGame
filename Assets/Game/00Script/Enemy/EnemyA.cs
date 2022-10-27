using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField]
    private Transform missilePos;

    [SerializeField]
    private GameObject missilePrefab;

    
    public override void Start()
    {
        base.Start();
        StartCoroutine(AttackCo(0.4f));
    }


    public override void Update()
    {
        
    }


    public override void Attack()
    {
       GameObject missile  =  Instantiate(missilePrefab);
       missile.transform.position = missilePos.position;
       StartCoroutine(AttackCo(0.4f));
    }

    IEnumerator AttackCo(float delayTime)
    {
        int delayAttack = 0;
        yield return new WaitForSeconds(delayTime);
        Attack();
    }
 
}
