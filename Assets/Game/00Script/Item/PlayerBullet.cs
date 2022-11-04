using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Missile
{

    private Vector3 dirVec3;

    public int count;
    public int Count
    {
        protected get => count;

        set
        {
            if (value >= 3)
            {
                count = 3;
               
            }
            else
            {
                count = value;
            }
        }
    }
    protected override void Start()
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
       
        switch (Count)
        {
            case 0:
                dirVec3 = Vector3.up;
                break;
            case 1:
                dirVec3 = Vector3.down;
                break;
            case 2:
                dirVec3 = Vector3.right;
                break;
            case 3:     
                dirVec3 = Vector3.left;
                break;
        }
    }

    protected override void Attack()
    {
        base.Attack();
        transform.position = transform.position + dirVec3 * Time.deltaTime * 2f;
    }
}
