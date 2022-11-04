using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour, ISecondPrartice
{
    private int ip;

    public int Ip
    {
        get => ip;

        set
        {
            value = ip;
        }
    }

    public void Car(int index, int indexTwo)
    {

    }

    public void Car(int index)
    {
        //왜 이걸 삭제를 하면 오류가 나는건지 
    }

    //이러면 결국 오버로딩 아닌가..?
    //
}
