using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


/*using Assets.Game._00Script;*/


public class GameManager : Singleton<GameManager>
{
    public void GameOver(bool isDie)
    {
        NormalGameManager.getInstace().MovePlayer();
    }

}                      
