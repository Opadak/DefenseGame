using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Shield : Item
    {
        protected override void Start()
        {
            base.Start();
          
        }

        private void OnEnable()
        {
           init();
        }

    protected override void init()
        {
            Count = 20;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
                return;

            else if (collision.gameObject.tag == "EnemyMissile" || collision.gameObject.tag == "BossMissile")
            {
                Count--;
                Debug.Log(Count);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                
            }



        }
    }


