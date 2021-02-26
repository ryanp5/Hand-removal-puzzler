using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMasterList<T> : ScriptableObject
{
    private List<T> genericList = new List<T>();
    public void Initialise()
    {
        genericList.Clear();
    }
    public T GetItemIndex(int index)
    {
        return genericList[index];
    }
    public List<T> ReturnList()
    {
        return genericList;
    }
    public void Add(T t)
    {
        if (!genericList.Contains(t)) genericList.Add(t);
    }
    public void Remove(T t)
    {
        if (genericList.Contains(t)) genericList.Remove(t);
    }
}
