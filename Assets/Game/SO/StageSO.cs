using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stage
{
    public int enemyKillCount;
    public GameObject[] revealEnemyType;
    public float enemySpawnTime;
    public bool isBossStage;
    public int rewardCoin;


}
[CreateAssetMenu(fileName = "StageSO", menuName = "Scriptable Object/StageSO")]
public class StageSO : ScriptableObject
{
    public Stage[] stages;
}
