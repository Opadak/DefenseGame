using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Missile : MonoBehaviour
{

    public virtual void Start()
    {
        transform.DOMove(Utils.playerPos.transform.position, 1f);
    }

    public virtual void Update() { }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
