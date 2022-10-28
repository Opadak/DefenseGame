using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
 

    protected override void Awake()
    {
        base.Awake();
        init();
    }

    protected override void Start()
    {
        base.Start();

    }


    protected override void Update()
    {
        base.Update();
    }
    protected override void init()
    {
        base.init();
        EnemyStat enemyStatB = new EnemyStat();
        enemyStatB.Hp = 2;
        enemyStatB.Speed = 0.8f;
        enemyStatB.Point = 2;


        speed = enemyStatB.Speed;
        hp = enemyStatB.Hp;
        point = enemyStatB.Point;
    }

   
    protected override void OnMouseDown()
    {
        
        base.OnMouseDown();

    }

    
}
