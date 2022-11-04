using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : Item
{
    [SerializeField]
    private GameObject playerbulletPrefab;
    
    private Vector3 dirVec3;

    private float Delay; // 차후 추가.. 

    private void OnEnable()
    {
        Attack();
       
    }

    private void Attack()
    {

        for (int i = 0; i < Level; i++)
        {

            Debug.Log(i + "i" + Level +"Level");
            GameObject gameObj = Instantiate(playerbulletPrefab, new Vector3(0, 0, 0), Utils.QI);
            gameObj.transform.parent = GameObject.Find("BulletDummy").transform;
            DummyManager.Instance.BulletObj = gameObj;
            PlayerBullet playerbullet = gameObj.GetComponent<PlayerBullet>();
            playerbullet.Count= i;
 
        
        }
        Invoke("SetActiveMagement", 1f);
    }


    private void SetActiveMagement()
    {
        gameObject.SetActive(false);
    }

    




}
