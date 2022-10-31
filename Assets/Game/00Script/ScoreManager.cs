using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void ScoreDelegate(int scorePlus);

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Inst { get; set; }
    void Awake() => Inst = this;

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

    public bool MinusScore(int scoreMinus)
    {
        int temp = score;
        score = score - scoreMinus;
        if (score < 0)
        {
            score = temp;
            return false;
        }
        else
        {
            
            return true;
        }
        
    }
    private void ResetScore()
    {
        score = 0;
    }
}
