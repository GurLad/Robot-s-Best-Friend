using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterTrigger : MonoBehaviour
{
    public bool OneTime;
    private Trigger[] triggers;
    private void Start()
    {
        triggers = GetComponents<Trigger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() == null)
        {
            return;
        }
        foreach (var item in triggers)
        {
            item.Activate();
        }
        if (OneTime)
        {
            Destroy(this);
        }
    }
}
