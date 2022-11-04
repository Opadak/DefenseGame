using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///Player의 아이템을 관리하는 스크립트 


public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private GameObject[] itemObjects; //Shield, PlayerBullet, [WideRangeAttack], Boom
    
    private BulletDirType bulletDirType;

    private Dictionary<GameObject,int> itemGrade = new Dictionary<GameObject,int>();
    
   protected override void Awake()
   {
        Init();
   }

    void Update()
    {

    }
    
    private void Init()
    {
        for(int i = 0; i < itemObjects.Length; i ++)
        {
            itemGrade.Add(itemObjects[i], 1);
        }
      
    }
   
 
    private void UpgradeItem(GameObject key)
    {
        int valueUp = (int)itemGrade[key];
        itemGrade[key] = valueUp + 1;
        
    }

    public void UpgradeBtn(GameObject key)
    {
        ScoreManager.Instance.MinusScore(10);
        //업그레이드 버전 마다 가격 다르게 
        UpgradeItem(key);

    }

    public void UseItem(GameObject key)
    {
        key.SetActive(true);
        Item item = key.GetComponent<Item>();
        item.Level = (int)itemGrade[key];
    }
}
