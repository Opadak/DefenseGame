using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSettingManager : MonoBehaviour
{
    private float mapX ;
    private float mapY = 4f;
    [SerializeField] GameObject groundPrefab;
   
    
    void Start()
    {
        MapSetting();
    }
    void MapSetting()
    {
        int index = 0;
       for (int i = 0; i < 10; i++)
        {
           
            mapX = ((-1f) * 0.9f * (i));
            for (int j = 0; j <= i; j++)
            {
                index++;
                Vector2 mapVec2 = new Vector2(mapX, mapY);
               Instantiate(groundPrefab, mapVec2, Quaternion.identity);
                mapX += 0.53f;
            }
            mapY = mapY - 0.3f;

        }
        for (int i = 0; i < 10; i++)
        {
            mapX = ((-1f) * 0.9f * (i));
            for (int j = 10; j >= i; j--)
            {
                index++;
                Vector2 mapVec2 = new Vector2(mapX, mapY);
                Instantiate(groundPrefab, mapVec2, Quaternion.identity);
                mapX += 0.53f;
            }
            mapY = mapY - 0.3f;
        }
    }
   
}
