using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagment : NormalGameManager
{
    public Hashtable eventHashtable = new Hashtable();

    public void AddHashtable(Object key, Object value)
    {
        eventHashtable.Add(key, value);
    }

    public void AddEventHashtable(Object key)
    {

    }


    public void RemoveHashtable(Object key)
    {
        eventHashtable.Remove(key);
    }
}
