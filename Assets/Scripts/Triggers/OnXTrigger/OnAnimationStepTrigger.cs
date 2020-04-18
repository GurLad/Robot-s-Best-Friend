using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationStepTrigger : MonoBehaviour, IAdvancedAnimationListener
{
    public AdvancedAnimation Animation;
    public int Step;
    private Trigger[] triggers;
    private void Start()
    {
        Animation.AdvancedAnimationListeners.Add(this);
        triggers = GetComponents<Trigger>();
    }
    public void OnStepChange(int nextStep)
    {
        if (nextStep == Step)
        {
            foreach (var item in triggers)
            {
                item.Activate();
            }
        }
    }
}
