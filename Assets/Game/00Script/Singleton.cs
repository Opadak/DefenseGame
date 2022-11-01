using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//MonoBehavior을 상속받는 Manager스크립트만 넣고 싶은데 이건 제약을 할 수 없나 ???
//Manager인터페이스를 따로 만들어서 이걸 제약으로 넣어도 괜찮을 거 같고 ,, ,,
public class Singleton <T>  : MonoBehaviour where T: MonoBehaviour
{
    
    private static T instance = null;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            return;
        }

        // 인스턴스가 null일 경우 해당 타입의 인스턴스를 찿아 반환한다
        instance = FindObjectOfType<T>();
    }
    protected virtual void OnDestroy()
    {
        if (instance != null) instance = null;
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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
