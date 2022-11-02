using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void killEnemyDelegate(int scorePlus);

public class SpawnManager : Singleton<SpawnManager>
{


    private GameObject[] enemies;

    private float enemySpawnDelay = 7f; // default°ª
    private int score;
    private int maxEnemyKillCount;
    private int curEnemyKillCount;
     


    public List<GameObject> enemyOnField = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        StageManager.Instance.stageEvent += StageRecieveEvent;
    }
    void Start()
    {

       
    }

    public void EnemySpawn(Vector2 spawnVec, int enemyIndex)
    {
        GameObject SpawnEnemy = Instantiate(enemies[enemyIndex], spawnVec, Utils.QI);
        enemyOnField.Add(SpawnEnemy);
    }
    internal void RecieveEnemyKill(int kill)
    {
        curEnemyKillCount += kill;
        if (curEnemyKillCount >= maxEnemyKillCount)
        {
            //Stage Clear
            Reset();
            StageManager.Instance.StopStage();
        }
        else
        {
            return;
        }

    }

    private void Reset()
    {      
        enemies = null;
        CleanEnemy();
        enemyOnField.Clear();
        CancelInvoke("RandomSpawnEnemy");
        curEnemyKillCount = 0;
    }
    private void StartInvoke()
    {
        InvokeRepeating("RandomSpawnEnemy", enemySpawnDelay, enemySpawnDelay);
    }
    
    private void CleanEnemy()
    {
        if (null == enemyOnField)
            return;
        for (int i = 0; i < enemyOnField.Count; i++)
        {
            Destroy(enemyOnField[i]);
        }
    }

    private void StageRecieveEvent(int stage, Stage _curStage)
    {
        Debug.Log(stage);
        enemies = _curStage.revealEnemyType;
        enemySpawnDelay = _curStage.enemySpawnTime;
        maxEnemyKillCount = _curStage.enemyKillCount;
        StartInvoke();
    }

    private void RandomSpawnEnemy()
    {

        int randomEnemy = Random.Range(0, enemies.Length);

        float randomX = Random.Range(-2.39f, 2.39f);
        float randomY = Random.Range(-3.11f, 4.6f);

        Vector2 RandomPos = new Vector2(randomX, randomY);

        EnemySpawn(RandomPos, randomEnemy);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if(enemyOnField != null)
        {
            enemyOnField.Clear();
        }
     
    }
}
