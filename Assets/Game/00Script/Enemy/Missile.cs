using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Missile : MonoBehaviour
{
    private float dirX;
    private float dirY;

    protected virtual void Start()
    {
        LaunchMissile();
       /* transform?.DOMove(Utils.playerPos.transform.position, 1f);*/
    }

    protected virtual void Update() {
        AttackPlayer();

    }

    private void LaunchMissile()
    {
       
        float playerX = Utils.playerPos.transform.position.x;
        float playerY = Utils.playerPos.transform.position.y;
        float thisX = transform.position.x;
        float thisY = transform.position.y;
        dirX = playerX - thisX >= 0 ? 1f : -1f;
        dirY = playerY - thisY >= 0 ? 1f : -1f;
     
    }
    private float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }

    protected virtual void AttackPlayer()
    {
        /*float rotZ = GetAngle(transform.position, Utils.playerPos.transform.position);
        transform.localEulerAngles = new Vector3(0, 0, rotZ);*/
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(dirX, dirY, 0) * 2f * Time.deltaTime;
        transform.position = curPos + nextPos;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
       
            Destroy(gameObject);
        }
    }
}
