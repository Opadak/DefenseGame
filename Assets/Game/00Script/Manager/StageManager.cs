using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StageEventHandler(int stage, Stage _curStage);
public class StageManager : Singleton<StageManager>
{ 
    [SerializeField]
    StageSO stageSO;
    private List<Stage> mystages;


    private int count;
    private int stage;
    private bool clear;
    
    public int Stage { get; set; }
 
    public StageEventHandler stageEvent;
    

    protected override void Awake()
    {
        base.Awake();
        SetUpStage();
      
    }

    private void Start()
    {
        StartStage();
    }

    private void SetUpStage()
    {
        mystages = new List<Stage>();
        for (int i = 0; i < stageSO.stages.Length; i++)
            {
                Stage stage = stageSO.stages[i];
                mystages.Add(stage);
            }
       
    }


    public void StartStage()
    {
        if (null != stageEvent)
        {
           
           stageEvent(Stage, mystages[Stage]);
           
        }
    }

    public void StopStage()
    {
        Stage++;
        UIManager.Instance.clearPanel.SetActive(true);
    }


    protected override void OnDestroy()
    {
        base.OnDestroy();
  
    }
}
