using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour, Observer
{
    [SerializeField] // display it in the Unity interface but don't make it public
    AudioSource pickupSound;
    [SerializeField]
    AudioSource dropSound;

    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.GreenCubeCollected || notificationType == NotificationType.RedCubeCollected || notificationType == NotificationType.OrangeCubeCollected)
        {
            pickupSound.Play();
        }

    }

    public void OnNotify(string s, NotificationType notificationType)
    {
        if (notificationType == NotificationType.ItemDropped)
        {
            dropSound.Play();
            // Sound from freeSound.org
            // https://freesound.org/people/MATRIXXX_/sounds/415991/
        }
    }

        void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

}
