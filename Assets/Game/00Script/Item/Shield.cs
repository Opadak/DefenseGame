using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int count;
   private void Awake()
    {
        count = 20;
    }

   private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(collision);
            count--;
            if (count <= 0)
                gameObject.SetActive(false);
        }
           
    }
}
