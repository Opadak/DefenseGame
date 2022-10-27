using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField]
    private Transform missilePos;

    [SerializeField]
    private GameObject missilePrefab;


    private float speed;
    private int hp;

    protected override void Awake()
    {
        base.Awake();
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
        enemyStat.SetSpeed(2f);
        enemyStat.SetHp(3);
        speed = enemyStat.GetSpeed();
        hp = enemyStat.GetHp();
        Debug.Log(speed + "" + hp);
    }
    protected override void Attack()
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
