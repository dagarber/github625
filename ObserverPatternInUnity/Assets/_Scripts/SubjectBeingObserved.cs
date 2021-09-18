using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectBeingObserved : MonoBehaviour // a class and not an interface
{
    private List<Observer> _observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(object obj, NotificationType notificationType)
    {
        foreach(Observer observer in _observers)
        {
            observer.OnNotify(obj, notificationType);
        }
    }

}
