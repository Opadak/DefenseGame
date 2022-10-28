using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public delegate void ScoreDelegate(int scorePlus);


public class GameManager : MonoBehaviour, IGameManager
{
    public static GameManager Inst { get; set; }
    void Awake() => Inst = this;


    [SerializeField]
    private TextMeshPro scoreTxt;
    [SerializeField]
    private TextMeshPro StageTxt;
    [SerializeField]
    private TextMeshPro LevelTxt;
    [SerializeField]
    private TextMeshPro HpTxt;
    [SerializeField]
    private Player player;
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private CastleSO castleSO;
    [SerializeField]
    private GameObject[] enemies;
    
    public List<Castle> myCastle;
    private int score;
    private void Start()
    {
        SetupCastleStat();
        SetUpLevelUp(0);
  

        InvokeRepeating("RandomSpawnEnemy",3f,1f);
    }
    #region IGameManager
    public void ShowScoreToTextMesh(int scorePlus)
    {
        score = score + scorePlus;
        scoreTxt.text = "Score " + score;
    }
    public void LevelUp(int level)
    {
        player.Setup(myCastle[level]);
        SetUpLevelUp(level);
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
    #endregion

    private void RandomSpawnEnemy()
    {

        int randomEnemy = Random.Range(0, enemies.Length);

        float randomX = Random.Range(-2.39f, 2.39f);
        float randomY = Random.Range(-4.6f, 4.6f);

        Vector2 RandomPos = new Vector2(randomX, randomY);

        EnemySpawn(RandomPos, randomEnemy);
    }
  

 
    public void SetUpLevelUp(int level)
    {
        LevelTxt.text = "Level " + myCastle[level].level;
        HpTxt.text = "Hp " + myCastle[level].hp;
        playerSprite.sprite = myCastle[level].castleSprite;
    }
    private void SetupCastleStat()
    {
        myCastle = new List<Castle>();
        for(int i = 0; i < castleSO.castles.Length; i++)
        {
            Castle castle = castleSO.castles[i];
            myCastle.Add(castle);
           
        }
        
    }
   
}                      
