using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterTrigger : MonoBehaviour
{
    private Trigger[] triggers;
    private void Start()
    {
        triggers = GetComponents<Trigger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in triggers)
        {
            item.Activate();
        }
    }
}
