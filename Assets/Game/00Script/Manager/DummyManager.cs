using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyManager : Singleton<DummyManager>
{
    private Queue<GameObject> bulleyQueue = new Queue<GameObject>();
    private GameObject bulletObj;

    private Coroutine OutputAdminCoroutine;

    public GameObject BulletObj
    {
        set
        {
           
            bulleyQueue.Enqueue(value);

        }
    }
    private void Start()
    {
        OutputAdminCoroutine = StartCoroutine(OutputAdminCo(2f));
    }

    #region OutputAdimin

    /// <summary>
    /// OutputAdmin�� Queue�� �׿��ִ� �����͸� delay ���ݿ� �ϳ��� ���� 
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator OutputAdminCo(float delay)
    {
        
        while (true)
        {
            yield return new WaitForSeconds(delay);
            OutPut();
        }

    }

    private void OutPut()
    {
        if (bulleyQueue.Count == 0)
            return;

        Destroy(bulleyQueue.Dequeue());
    }
    #endregion
}
