using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLoadScene : Trigger
{
    public string Name;
    public override void Activate()
    {
        SceneManager.LoadScene(Name);
    }
}
