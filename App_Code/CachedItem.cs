using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CachedItem
/// </summary>
public class CachedItem<T>
{
    private T _item;
    private DateTime _expires;

    public CachedItem(T item, DateTime expires)
    {
        _item = item;
        _expires = expires;
    }

    public T Item
    {
        get { return _item; }
    }

    public bool IsExpired
    {
        get { return DateTime.Now > _expires; }
    }
}