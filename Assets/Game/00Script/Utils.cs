using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Quaternion QI => Quaternion.identity;
    public static Transform playerPos {
        get
        {
            GameObject playerPos = GameObject.FindGameObjectWithTag("Player");
            return playerPos.transform;
        }
    }
}
