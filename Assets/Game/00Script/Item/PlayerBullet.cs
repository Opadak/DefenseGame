using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Missile
{

    private Vector3 dirVec3;

    private int count;
    public int Count { private get;  set; }

    private void Awake()
    {
        base.Start();
        Init();
    }


    protected override void Update()
    {
        base.Update();
    }

    private void Init()
    {
        var dirType = (BulletDirType)Count;
        switch (dirType)
        {
            case BulletDirType.RIGHT:
                dirVec3 = Vector3.right;
                break;
            case BulletDirType.LEFT:
                dirVec3 = Vector3.left;
                break;
            case BulletDirType.UP:
                dirVec3 = Vector3.up;
                break;
            case BulletDirType.DOWN:
                dirVec3 = Vector3.down;
                break;
        }
    }

    protected override void Attack()
    {
        base.Attack();
        transform.position = transform.position + dirVec3 * Time.deltaTime * 2f;
    }
}
