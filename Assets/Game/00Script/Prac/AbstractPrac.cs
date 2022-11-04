using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractP
{
    abstract class AbstractPrac
    {

        public void GetNull()
        {
            return;
        }
        public abstract void GetArea();
    }

     class Square : AbstractPrac
    {
        public override void GetArea()
        {
            int[] arr = { 1, 2, 3, 4 };

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    
                }
            }
            catch(IndexOutOfRangeException)
            {
                //인덱스의 범위가 넘어갔다는 경고문
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //뒷정리 코드 작성
            }


        }
    }

    class MyException : Exception
    {
        public MyException()
        {

        }
        public MyException(string message):base (message)
        {

        }
    }
}

