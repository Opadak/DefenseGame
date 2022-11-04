using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///Player�� �������� �����ϴ� ��ũ��Ʈ 


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
        //���׷��̵� ���� ���� ���� �ٸ��� 
        UpgradeItem(key);

    }

    public void UseItem(GameObject key)
    {
        key.SetActive(true);
        Item item = key.GetComponent<Item>();
        item.Level = (int)itemGrade[key];
    }
}
