using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer //: MonoBehaviour
    //interface rather than class is how we get around multiple inheritances
{
    public void OnNotify(object obj, NotificationType notificationType);
    // any object can be passed using the object type
    // it's only there temporarily and thus it does not create any coupling in code
    // OnNotify is unimplemented; each observer will implement it
}

public enum NotificationType
{
    //enum are numbers which have names
    RedCubeCollected, // 0
    GreenCubeCollected // 1


}
