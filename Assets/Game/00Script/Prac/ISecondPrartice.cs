using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISecondPrartice : IPractice
{
    void Car(int index, int indexTwo);
    //인터페이스가 인터페이스를 상속 받을 때 약속을 안지켜도 되는지 물어보기 >> 만약 약속을 지키지 않아도 된다면 왜 그래야 하는지도.
}
