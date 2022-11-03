using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : Item
{
    [SerializeField]
    private GameObject playerbulletPrefab;
    
    private Vector3 dirVec3;

    private void OnEnable()
    {
        Attack();
       
    }

    private void Attack()
    {
        for(int i = 0; i < Level; i++)
        {
            GameObject gameObj = Instantiate(playerbulletPrefab, Utils.playerPos);
            PlayerBullet playerbullet = gameObj.GetComponent<PlayerBullet>();
            playerbullet.Count= i;
        }
        gameObject.SetActive(false);
    }


    




}
