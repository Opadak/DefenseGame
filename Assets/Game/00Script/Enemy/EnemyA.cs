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
        StartCoroutine(AttackCo(0.4f));
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void init()
    {
        base.init();
        EnemyStat enemyStat = new EnemyStat();
        enemyStat.Speed = 2f;
        enemyStat.Hp = 3;
        enemyStat.Damage = 1;
   
        speed = enemyStat.Speed;
        hp = enemyStat.Hp;
        damage = enemyStat.Damage;
 
    }

    protected override void Attack()
    {
        GameObject missile = Instantiate(missilePrefab);
        missile.transform.position = missilePos.position;
        StartCoroutine(AttackCo(0.4f));
    }
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Inst.ShowScoreToTextMesh(damage);
        //이걸 이벤트 핸들러로 바꾸고 싶음. 
        Destroy(gameObject);
    }
    IEnumerator AttackCo(float delayTime)
    {
        int delayAttack = 0;
        yield return new WaitForSeconds(delayTime);
        Attack();
    }
 
}
