using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Castle
{
    public int level;
    public int hp;
    public Sprite castleSprite;
    //레벨에 따른 scale 추가 
}


[CreateAssetMenu(fileName = "CastleSO", menuName = "Scriptable Object/CastleSO")]
public class CastleSO : ScriptableObject
{
    public Castle[] castles;
    
}

