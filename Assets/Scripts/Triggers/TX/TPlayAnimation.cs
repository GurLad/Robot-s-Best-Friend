using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayAnimation : ContinuousTrigger
{
    public AdvancedAnimation Target;
    private bool started = false;
    private void Update()
    {
        if (started && !Target.Active)
        {
            started = false;
            done = true;
        }
    }

    public override void Activate()
    {
        started = true;
        Target.Activate(true);
    }
}
