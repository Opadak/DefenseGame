using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletProperty : Singleton<PlayerBulletProperty>
{
    private BulletDirType bulletDirType;

    public BulletDirType BulletDirType { get;  set; }
}
