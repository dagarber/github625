using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScore : MonoBehaviour
{
    private static int score;

    void Awake()
    {
        //Debug.Log("Awake " + score);
        DontDestroyOnLoad(this.gameObject);
        //Debug.Log("Awake " + score);
    }

    public int GetScore()
    {
        //Debug.Log("RETURN SCORE: " + score);
        return score;
    }

    public void ChangeScore(int i)
    {
        score = i;
        //Debug.Log("DONT DESTROY SCORE: " + score);
    }

}
