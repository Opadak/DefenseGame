using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
interface IGameManager 
{
    /// <summary>
    /// Score에 점수가 올라갈 때 마다 실행되는 함수 
    /// </summary>
    /// <param name="scoreTxt"> Score 반영 TextMeshPro</param>
    /// <param name="scorePlus">Score에 추가되는 점수</param>
    void ShowScoreToTextMesh(TextMeshPro scoreTxt, int scorePlus);
    /// <summary>
    /// LevelUp이 되면 Castle의 정보가 바뀜.
    /// </summary>
    /// <param name="castleSO">Castle의 정보가 들어있는 List</param>
    /// <param name="index">level이 up이 되면 그에 맞는 정보를 player에게 Setup</param>
    /// <returns></returns>
    Castle LevelUp(Castle[] castle, int level);
    /// <summary>
    /// Castle의 State 정보 Update
    /// </summary>
    /// <param name="castleState"></param>
    /// <param name="playerHp"></param>
    /// <returns></returns>
    CastleState UpdateCastleState(int playerHp);
    /// <summary>
    /// 캐슬의 정보를 체크해주는 함수
    /// </summary>
    /// <param name="castleState"></param>
    /// <returns>BAD일시 true를 리턴함</returns>
    bool CheckCastleState(CastleState castleState);

    
}

enum CastleState : int
{
    VERY_GOOD,
    GOOD,
    NOT_BAD,
    BAD
}
