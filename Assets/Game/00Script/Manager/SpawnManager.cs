using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    private GameObject[] enemies;

    private float enemySpawnDelay = 5f;
    private int score;
    void Start()
    {

        InvokeRepeating("RandomSpawnEnemy", enemySpawnDelay, 1f);
    }

    public void EnemySpawn(Vector2 spawnVec, int enemyIndex)
    {
        GameObject SpawnEnemy = Instantiate(enemies[enemyIndex], spawnVec, Utils.QI);
    }

 


    private void RandomSpawnEnemy()
    {

        int randomEnemy = Random.Range(0, enemies.Length);

        float randomX = Random.Range(-2.39f, 2.39f);
        float randomY = Random.Range(-4f, 4.6f);

        Vector2 RandomPos = new Vector2(randomX, randomY);

        EnemySpawn(RandomPos, randomEnemy);
    }
}
