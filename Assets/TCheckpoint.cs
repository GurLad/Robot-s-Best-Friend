using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCheckpoint : Trigger
{
    public override void Activate()
    {
        PlayerController.StartPos = new Vector3(transform.position.x, 0, transform.position.z);
        if (PlayerController.Instance != null)
        {
            Health playerHealth = PlayerController.Instance.GetComponent<Health>();
            playerHealth.HP = playerHealth.Healthbar.Max;
            playerHealth.Healthbar.Value = playerHealth.HP;
        }
    }
}
