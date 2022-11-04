using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void ScoreDelegate(int scorePlus);

public class ScoreManager : Singleton<ScoreManager>
{ 

    private static int score;


    [SerializeField]
    private TextMeshPro scoreTxt;
    
   
   
    private void ShowScoreToTextMesh()
    {
        scoreTxt.text = "Score " + score;
    }

    internal void PlusScore(int scorePlus)
    {
        score = score + scorePlus;
        ShowScoreToTextMesh();
    }

    public bool CheckScore(int scoreMinus)
    {
        int temp = score;
        temp = temp - scoreMinus;
        if (temp <= 0)
        {            
            Debug.Log("돈이 없습니다.");
            return false;
        }
        else
        {
            
            return true;
        }
        
    }
    public void MinusScore(int scoreMinus)
    {
        bool isMinus = CheckScore(scoreMinus);
        if (isMinus)
        {
            score = score - scoreMinus;
            ShowScoreToTextMesh();
        }
        else
        {
            return;
        }
    }

    private void ResetScore()
    {
        score = 0;
    }
}
