using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRunAI : MonoBehaviour
{
    //Mono-Rat Aggro
    public float Speed;
    public Vector3 Velocity;
    private Rigidbody rigidbody;
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Velocity.y = 0;
        rigidbody.velocity = Velocity + new Vector3(0, rigidbody.velocity.y, 0);
        transform.LookAt(transform.position + Velocity);
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, 1, ~(1 << 8)))
        {
            ChangeDirection();
        }
        Velocity.y = 0;
        rigidbody.velocity = Velocity + new Vector3(0, rigidbody.velocity.y, 0);
        transform.LookAt(transform.position + Velocity);
    }
    private void ChangeDirection()
    {
        rigidbody.velocity = Velocity = ((new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * Speed)) + new Vector3(0, rigidbody.velocity.y, 0);
        transform.LookAt(transform.position + Velocity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerController>() != null)
        {
            RatAI.Instance.Body.SetActive(true);
            RatAI.Instance.Backpack.enabled = true;
            RatAI.Instance.CloseLid();
            Destroy(gameObject);
        }
    }
}
