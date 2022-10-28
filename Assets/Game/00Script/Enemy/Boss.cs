using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    private Transform missilePosR;
    [SerializeField]
    private Transform missilePosL;
    [SerializeField]
    private GameObject missilePrefab;
    protected override void Awake()
    {
        init();
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Attack", 3f, 1);
    }


    protected override void Update()
    {
        base.Update();
    }
    protected override void init()
    {
     
        EnemyStat boss = new EnemyStat();
        boss.Speed = 0.1f;
        boss.Hp = 3;
        boss.Point = 8;
     

        speed = boss.Speed;
        hp = boss.Hp;
        point = boss.Point;
  
    }
    protected override void Attack()
    {
        GameObject missileR = Instantiate(missilePrefab);
        GameObject missileL = Instantiate(missilePrefab);
        missileR.transform.position = missilePosR.position;
        missileL.transform.position = missilePosL.position;
       
    }
    }
