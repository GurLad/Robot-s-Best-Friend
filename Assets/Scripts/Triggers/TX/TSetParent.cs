using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSetParent : Trigger
{
    public Transform Transform;
    public Transform Parent;
    public override void Activate()
    {
        Transform.parent = Parent;
    }
}
