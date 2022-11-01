using UnityEditor;
using UnityEngine;

namespace Assets.Game._00Script
{
    public class NormalGameManager
    {
        private static NormalGameManager listener = null;

        public static NormalGameManager getInstace()
        {
            if(listener == null)
            {
                listener = new NormalGameManager();
            }

            return listener;
        }

        public void MovePlayer()
        {

        }
        //monoBehavior이라는 것을 굳이 사용하지 않아도 됨. 내가 헷갈려 했던 건 
        // 무조건 GameObject에서 Attaching시켜서 사용하려고 했기 때문! 
        //StatusEvent 스크립트 같이 데이터를 받는 용도로 사용한다면 
        //굳이 monoBehavior을 상속하지 않고 GameObject상에 안 올려도 되기 때문에! 
        //한번 이걸 토대로 만들어보자 ㅇㅇ 
    }
}