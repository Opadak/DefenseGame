using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Day = System.DayOfWeek;

public class MyClassA<T>
{
    private List<T> list;

    public List<T> MyList { get { return list; } set { list = value; } }
}

/*public class MyClassB
{
    private List<T> list;

    public List<T> MyList { get { return list; } set { list = value; } }
}*/

class MyClassMain
{

    static void Main(string[] args)
    {
        MyClassA<int> x = new MyClassA<int>();
        x.MyList.Add(1);
    }
}

class MyListIndexerPrac
{
    float[] temp = new float[10]
    {
      56.2f, 56.7f, 56.5f, 56.9f, 58.8f,
        61.3f, 65.9f, 62.1f, 59.2f, 57.5f
    };

    public int Length => temp.Length;

    public float this[int index]
    {
        get => temp[index];
        set => temp[index] = value;
    }

    //인덱서의 인덱스가 Console.write 문 등에서 평가될 때 get접근자가 호출이 된다. 
    //따라서 get접근자가 없으면 컴파일 시간 오류가 발생된다. 


}


public class MyListIndexerPrac2
{
    string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

    public int this[string day] => FindDayIndex(day);

    private int FindDayIndex(string day)
    {
     for(int i = 0; i < days.Length; i++)
        {
            if(days[i] == day)
            {
                return i;
            }
        }

        throw new ArgumentOutOfRangeException(
           nameof(day),
           $"Day {day} is not supported.\nDay input must be a defined System.DayOfWeek value.");


    }
}

/*class Program
{
    static void main()
    {
        var week = new MyListIndexerPrac2();

        Console.WriteLine(week[DayOfWeek.Friday]);
        // public int this[string day] => FindDayIndex(day);

        try
        {
            Console.WriteLine(week[(DayOfWeek)43]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Not supported input: {e.Message}");
        }
    }
}*/










