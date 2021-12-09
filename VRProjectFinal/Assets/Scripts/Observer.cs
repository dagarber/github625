using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer
{
    void OnNotify(GameObject obj, NotificationType notificationType);
    void OnNotify(string s, NotificationType notificationType);
    bool checkFell();
}

public enum NotificationType
{
    BowledTwice
}

