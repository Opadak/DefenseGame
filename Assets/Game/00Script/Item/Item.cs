using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Item : Singleton<MonoBehaviour>
{

    private int level;

    public int Level
    {
        protected get => level;

        set
        {
            if(value >= 4)
            {
              
                level = 4;
               
            }
            else
            {
                level = value;
            }
        }

    }

   
    protected virtual void Start() { }
 

    protected virtual void init() { }


    }




