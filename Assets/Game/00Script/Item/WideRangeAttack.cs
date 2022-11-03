using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class WideRangeAttack : Shield
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
                return;

            else if (collision.gameObject.tag == "EnemyMissile" || collision.gameObject.tag == "BossMissile")
            {
                Count--;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                 
            }



        }
    }

