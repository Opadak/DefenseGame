using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>  : MonoBehaviour where T: MonoBehaviour
{
    
    private static Singleton<T> instance = null;

    void Awake()
    {
        if (null == instance)
        {
            
            instance = this;
           //����ȯ �ı� x
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static Singleton<T> Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
        set
        {

        }
    }
}
