using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField]
    private Transform missilePos;
    [SerializeField]
    private GameObject missilePrefab;

    
    /*public event EventHandler Click;*/
    protected override void Awake()
    {
        base.Awake();
        init();
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(AttackCo(delayMissile));
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void init()
    {
        base.init();
        EnemyStat enemyStatA = new EnemyStat();
        enemyStatA.Speed = 0.3f;
        enemyStatA.Hp = 0;
        enemyStatA.Point = 1;
        enemyStatA.DelayMissile = 0.4f;

        speed = enemyStatA.Speed;
        hp = enemyStatA.Hp;
        point = enemyStatA.Point;
        delayMissile = enemyStatA.DelayMissile;
    }

    protected override void Attack()
    {
        GameObject missile = Instantiate(missilePrefab);
        missile.transform.position = missilePos.position;
        StartCoroutine(AttackCo(1f));
    }

    protected override void MoveToPlayer()
    {

    }
    protected override void OnMouseDown()
    {
        
        //이걸 이벤트 핸들러로 바꾸고 싶음. 
        base.OnMouseDown();

    }
    IEnumerator AttackCo(float delayTime)
    {
        
        yield return new WaitForSeconds(delayTime);
        Attack();
    }
 
}
