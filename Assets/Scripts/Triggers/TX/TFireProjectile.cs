using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFireProjectile : Trigger
{
    public Rigidbody Projectile;
    public float Speed;
    public Transform Spawner;
    private void Reset()
    {
        Spawner = transform;
    }
    public override void Activate()
    {
        GameObject projectile = Instantiate(Projectile.gameObject);
        projectile.transform.position = Spawner.position;
        projectile.transform.forward = Spawner.forward;
        projectile.GetComponent<Rigidbody>().velocity = Speed * projectile.transform.forward;
        projectile.SetActive(true);
    }
}
