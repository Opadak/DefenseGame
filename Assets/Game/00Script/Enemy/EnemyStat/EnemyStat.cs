using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyStat
{
    private float speed;
    private int hp;

    public float GetSpeed() { return speed; }
    public void SetSpeed(float _speed) { speed = _speed; }

    public int GetHp() { return hp; }
    public void SetHp(int _hp) { hp = _hp; }

}
