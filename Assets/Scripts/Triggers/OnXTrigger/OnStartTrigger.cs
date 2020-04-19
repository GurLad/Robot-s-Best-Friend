using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartTrigger : MonoBehaviour
{
    private Trigger[] triggers;
    private void Start()
    {
        triggers = GetComponents<Trigger>();
        foreach (var item in triggers)
        {
            item.Activate();
        }
    }
}
