using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPause : Trigger
{
    public override void Activate()
    {
        Time.timeScale = 0;
    }
}
