using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayMusic : Trigger
{
    public string Name;
    public override void Activate()
    {
        CrossfadeMusicPlayer.Instance.Play(Name);
    }
}
