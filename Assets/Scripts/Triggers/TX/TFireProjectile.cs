using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFireProjectile : Trigger
{
    public Rigidbody Projectile;
    public float Speed;
    public Transform Spawner;
    public GameObject ToFollow;
    private void Reset()
    {
        Spawner = transform;
    }
    public override void Activate()
    {
        GameObject projectile = Instantiate(Projectile.gameObject);
        projectile.transform.position = Spawner.position;
        if (ToFollow == null)
        {
            projectile.transform.forward = Spawner.forward;
        }
        else
        {
            projectile.transform.LookAt(ToFollow.transform);
        }
        projectile.GetComponent<Rigidbody>().velocity = Speed * projectile.transform.forward;
        projectile.SetActive(true);
    }
}
