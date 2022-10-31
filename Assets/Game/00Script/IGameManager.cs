using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
interface IGameManager
{

    /// <summary>
    /// LevelUp이 되면 Castle의 정보가 바뀜.
    /// </summary>
    /// <param name="index">level이 up이 되면 그에 맞는 정보를 player에게 Setup</param>
    /// <returns></returns>
    void LevelUp(int level);
    /// <summary>
    /// Castle의 State 정보 Update
    /// </summary>
    /// <param name="playerHp"></param>
    /// <returns> State 정보값을 반환 </returns>
    int UpdateCastleState(int playerHp);
    /// <summary>
    /// 캐슬의 정보를 체크해주는 함수
    /// </summary>
    /// <param name="Player"></param>
    /// <returns>BAD일시 true를 리턴함</returns>
    bool CheckCastleState(Player player);

    void EnemySpawn(Vector2 spawnVec, int enemyIndex);

    /// <summary>
    /// 플레이어가 죽었을 때 게임이 멈추고 게임 오버 패널이 나오게 하기. 
    /// </summary>
    /// <param name="isDie"></param>
    void GameOver(bool isDie);

    
}


