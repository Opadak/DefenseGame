using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Item : Singleton<MonoBehaviour>
{

    private int count;
    private int level;
    public int Count
        {
           protected get => count;

        set 
            {
            if (value <= 0)
            {
                count = 0;
                Debug.Log("");
                gameObject.SetActive(false);
            }
            else
            {
                count = value;
            }
        }
        }
    public int Level
    {
        protected get => level;

        set
        {
            if(value >= 4)
            {
                Debug.Log("���׷��̵� �� �� �����ϴ�. ");
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




