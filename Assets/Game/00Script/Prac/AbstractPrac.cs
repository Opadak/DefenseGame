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
                //�ε����� ������ �Ѿ�ٴ� ���
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //������ �ڵ� �ۼ�
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

