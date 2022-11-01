using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//MonoBehavior�� ��ӹ޴� Manager��ũ��Ʈ�� �ְ� ������ �̰� ������ �� �� ���� ???
//Manager�������̽��� ���� ���� �̰� �������� �־ ������ �� ���� ,, ,,
public class Singleton <T>  : MonoBehaviour where T: MonoBehaviour
{
    
    private static T instance = null;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            return;
        }

        // �ν��Ͻ��� null�� ��� �ش� Ÿ���� �ν��Ͻ��� �O�� ��ȯ�Ѵ�
        instance = FindObjectOfType<T>();
    }
    protected virtual void OnDestroy()
    {
        if (instance != null) instance = null;
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static T Instance
    {
        get
        {
            if (instance == null)
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
