using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string name;
    public float curHp;
    public float maxHp;
    public float speed;
    public string damage;
    public Sprite enemySprite;
   

}


[CreateAssetMenu(fileName ="EnemySO" , menuName = "Scriptable Object/BasicCardSO")]
public class EnemySO : ScriptableObject
{
    public Enemy[] enemies;
    
}
