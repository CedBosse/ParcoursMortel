using System;
using System.Collections.Concurrent;
public class BagEmptyException : ApplicationException {}
public class ObjectPool<T>
{
    public ObjectPool()
    {
        Objects = new ConcurrentBag<T>();
    }
    public ConcurrentBag<T> Objects { get; private set; }

    public T GetObject()
    {
        T selectedObject;
        if (!Objects.TryTake(out selectedObject))
            throw new BagEmptyException();
        return selectedObject;
    }

    public void PutObject(T objectToPut)
    {
        Objects.Add(objectToPut);
    }
}