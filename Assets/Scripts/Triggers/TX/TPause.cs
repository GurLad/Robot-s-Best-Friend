using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPause : Trigger
{
    public bool Pause = true;
    public override void Activate()
    {
        Time.timeScale = Pause ? 0 : 1;
    }
}
