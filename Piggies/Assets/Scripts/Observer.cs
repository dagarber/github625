using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer
{
    void OnNotify(object obj, NotificationType notificationType, bool bol);
}

public enum NotificationType
{
    Level1Hit,
    Level2Hit,
    Level3Hit
}