using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OnOffMode { On, Off, Switch }
public class TEnableDisable : Trigger
{
    public OnOffMode TargetState;
    public GameObject Target;

    public override void Activate()
    {
        switch (TargetState)
        {
            case OnOffMode.On:
                Target.SetActive(true);
                break;
            case OnOffMode.Off:
                Target.SetActive(false);
                break;
            case OnOffMode.Switch:
                Target.SetActive(!Target.activeSelf);
                break;
            default:
                break;
        }
    }
}
