using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    private Button button;


    private int price;

    public int Price
    {
        get => price;

        set
        {
          price = value * 10;
        }
    }

    private void Start()
    {
        button = GetComponent<Button>();
    }
    public void Enable()
    {
        Init();
        Debug.Log("isEnable");
     
    }

    public void Init()
    {
            button.interactable = ScoreManager.Instance.CheckScore(Price);
    }





}
