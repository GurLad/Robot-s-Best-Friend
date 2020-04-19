using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSetBlackScreen : ContinuousTrigger
{
    public bool On;
    private bool checking;
    public override void Activate()
    {
        BlackScreen.Set(On);
        checking = true;
        done = false;
    }

    private void Update()
    {
        if (checking && BlackScreen.Finished)
        {
            done = true;
            checking = false;
        }
    }
}
