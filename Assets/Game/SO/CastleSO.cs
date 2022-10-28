using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Castle
{
    public int level;
    public int hp;
    public Sprite castleSprite;
    //������ ���� scale �߰� 
}


[CreateAssetMenu(fileName = "CastleSO", menuName = "Scriptable Object/CastleSO")]
public class CastleSO : ScriptableObject
{
    public Castle[] castles;
    
}

