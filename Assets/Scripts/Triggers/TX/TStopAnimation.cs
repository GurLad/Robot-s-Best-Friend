using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TStopAnimation : Trigger
{
    public AdvancedAnimation Target;
    public override void Activate()
    {
        Target.Active = false;
    }
}
