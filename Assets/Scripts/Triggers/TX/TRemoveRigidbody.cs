using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRemoveRigidbody : Trigger
{
    public Rigidbody rigidbody;
    public override void Activate()
    {
        Destroy(rigidbody);
    }
}
