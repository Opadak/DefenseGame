using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyStat
{
    private float speed;
    private int hp;
    private int point;
    private float delayMissile;
    private bool isBoss;
    public float Speed { get; set; }

    public int Hp { get; set; }


    public int Point { get; set;}

    public float DelayMissile { get; set; }

    /*public abstract bool IsBoss { get; set; }*/
    //추상프로퍼티는 추상클래스 안에서만 선언이 가능하다. 
    
}
