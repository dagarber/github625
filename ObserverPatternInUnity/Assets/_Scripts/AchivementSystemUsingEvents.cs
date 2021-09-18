using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystemUsingEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CubeCollectionNotifier.OnCubeColleted += UnlockCubeCollectedAchievement;
        CubeCollectionNotifier.OnCubeColleted += PlaySoundForAchievement;
        SphereCollectionNotifier.OnSphereCollected += UnlockSphereCollectedAchievement;
        
    }

    private void UnlockCubeCollectedAchievement(CubeCollectionNotifier c)
    {
        Debug.Log("Congrats! You achieved a lot! I mean, you got a cube.");
    }

    private void UnlockSphereCollectedAchievement(string c)
    {
        Debug.Log(c);
    }

    private void PlaySoundForAchievement (CubeCollectionNotifier c)
    {
        Debug.Log("Ping!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
