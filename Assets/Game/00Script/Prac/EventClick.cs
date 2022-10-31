using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EventClickHandler
{
   
    public event EventHandler Click;
    public void MouseButtonDown()
    {
        if (this.Click != null)
        {
            // 이벤트핸들러들을 호출
            Click(this, EventArgs.Empty);
            Debug.Log("이벤트핸들러 호출");
        }
    }

}

public class EventClick : MonoBehaviour
{
    public void Start()
    {
        EventClickHandler eventBtn = new EventClickHandler();
        eventBtn.Click += new EventHandler(btn_Click);

    }


    public void btn_Click(object sender, EventArgs e)
    {
       
        Debug.Log("버튼 클릭");
    }

    public void btn(string btnName)
    {
       
        btn_Click(btnName, EventArgs.Empty);
    }
}



