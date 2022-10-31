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
            // �̺�Ʈ�ڵ鷯���� ȣ��
            Click(this, EventArgs.Empty);
            Debug.Log("�̺�Ʈ�ڵ鷯 ȣ��");
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
       
        Debug.Log("��ư Ŭ��");
    }

    public void btn(string btnName)
    {
       
        btn_Click(btnName, EventArgs.Empty);
    }
}



