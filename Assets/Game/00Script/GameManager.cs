using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; set; }
    void Awake() => Inst = this;

    [SerializeField]
    private GameObject[] enemies;

    private float enemySpawnDelay = 5f; 
    private int score;
     void Start()
    {
       
        InvokeRepeating("RandomSpawnEnemy", enemySpawnDelay, 1f);
    }
   
    public int UpdateCastleState(int playerHp)
    {
        throw new System.NotImplementedException();
    }

    public bool CheckCastleState(Player player)
    {
        throw new System.NotImplementedException();
    }
    public void EnemySpawn(Vector2 spawnVec, int enemyIndex)
    {
        GameObject SpawnEnemy = Instantiate(enemies[enemyIndex], spawnVec, Utils.QI);
    }

    public void GameOver(bool isDie)
    {
        
    }


    private void RandomSpawnEnemy()
    {

        int randomEnemy = Random.Range(0, enemies.Length);

        float randomX = Random.Range(-2.39f, 2.39f);
        float randomY = Random.Range(-4.6f, 4.6f);

        Vector2 RandomPos = new Vector2(randomX, randomY);

        EnemySpawn(RandomPos, randomEnemy);
    }
  

 
   
 
   
}                      
