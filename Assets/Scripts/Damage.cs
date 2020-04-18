using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float Lifespan = Mathf.Infinity;
    public bool IsEnemy;
    public float Amount;

    void Update()
    {
        Lifespan -= Time.deltaTime;
        if (Lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }    
}
