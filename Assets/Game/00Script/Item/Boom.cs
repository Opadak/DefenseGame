using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Boom : Item
    {

    protected override void Start()
    {
        base.Awake();
       
    }

    private void OnEnable()
    {
        ActiveBoom();
    }
    public void ActiveBoom()
     {
        SpawnManager.Instance.CleanEnemy();
        SpawnManager.Instance.enemyOnField.Clear();
        gameObject.SetActive(false);
    }
    }

