using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool answer = IsPrime (23, 2);
        if (answer) Debug.Log ("It's prime!");
        else Debug.Log ("It's not prime!");
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public bool IsPrime (int n, int i)
    {
        //int x; // THIS IS HOW YOU WOULD DO IT WITH A LOOP (NON-RECURSIVELY)
        //for(int c = 2; c < x/2; c++ ) {
        //    if (x % c == 0) return "NO! IT IS NOT PRIME"
        //}

        if (i > n / 2) return true;
        if (n % i == 0) return false;

        return IsPrime (n, i+1);

        //i = i + 1;

    }
}
