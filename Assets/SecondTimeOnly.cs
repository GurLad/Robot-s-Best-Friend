using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTimeOnly : MonoBehaviour
{
    private static bool firstTime = true;
    private void Start()
    {
        if (firstTime)
        {
            firstTime = false;
            Destroy(gameObject);
        }
    }
}
