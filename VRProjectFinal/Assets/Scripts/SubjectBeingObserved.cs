using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectBeingObserved : MonoBehaviour // a class and not an interface
{
    protected List<Observer> _observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

    }

    public void RemoveObserver(Observer observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(GameObject obj, NotificationType notificationType)
    {
        foreach(Observer observer in _observers)
        {
            observer.OnNotify(obj, notificationType);
        }
    }

    public void Notify(string s, NotificationType notificationType)
    {
        foreach (Observer observer in _observers)
        {
            observer.OnNotify(s, notificationType);
        }
    }

}
