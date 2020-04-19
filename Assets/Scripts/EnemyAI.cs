using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SavedData;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float Speed;
    public float AttackRange;
    public float StartAttackRange;
    public float Range;
    [Header("Voices")]
    public AudioClip[] Clips;
    [Header("Animations")]
    public AdvancedAnimation WalkAnimation;
    public AdvancedAnimation IdleAnimation;
    public AdvancedAnimation LookAnimation;
    public AdvancedAnimation FireAnimation;
    [Header("Objects")]
    public TFireProjectile ProjectileSpawner;
    private PlayerController player;
    private Rigidbody rigidbody;
    private AdvancedAnimation activeAnimation;
    private bool justFound;
    private void Start()
    {
        player = PlayerController.Instance;
        rigidbody = GetComponent<Rigidbody>();
        activeAnimation = IdleAnimation;
        if (Load<int>("Difficulty") == 0)
        {
            Range /= 2;
        }
    }
    private void Update()
    {
        RaycastHit hit;
        if (RatRunAI.Instance != null)
        {
            Physics.Raycast(transform.position, RatRunAI.Instance.transform.position - transform.position, out hit, float.MaxValue, ~(1 << 8));
            Debug.DrawRay(transform.position, RatRunAI.Instance.transform.position - transform.position, Color.green);
            if (hit.transform != null && hit.transform.GetComponentInParent<RatRunAI>() != null && Vector3.Distance(RatRunAI.Instance.transform.position, transform.position) < Range)
            {
                ProjectileSpawner.ToFollow = RatRunAI.Instance.gameObject;
                if (justFound)
                {
                    justFound = false;
                    SoundController.PlaySound(Clips[Random.Range(0, Clips.Length)], false);
                }
                LookAt(RatRunAI.Instance.transform.position);
                if ((activeAnimation != FireAnimation && activeAnimation != LookAnimation && Vector3.Distance(RatRunAI.Instance.transform.position, transform.position) > StartAttackRange) ||
                    ((activeAnimation == FireAnimation || activeAnimation == LookAnimation) && Vector3.Distance(RatRunAI.Instance.transform.position, transform.position) > AttackRange))
                {
                    rigidbody.velocity = transform.forward * Speed;
                    if (!WalkAnimation.Active)
                    {
                        activeAnimation.Active = false;
                        activeAnimation = WalkAnimation;
                        WalkAnimation.Activate(true);
                    }
                }
                else
                {
                    if (activeAnimation != FireAnimation && activeAnimation != LookAnimation)
                    {
                        activeAnimation.Active = false;
                        activeAnimation = LookAnimation;
                        LookAnimation.Activate(true);
                    }
                    else if (activeAnimation == LookAnimation && !LookAnimation.Active)
                    {
                        activeAnimation.Active = false;
                        activeAnimation = FireAnimation;
                        FireAnimation.Activate(true);
                    }
                }
                return;
            }
        }
        Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, float.MaxValue, ~(1 << 8));
        Debug.DrawRay(transform.position, player.transform.position - transform.position);
        if (hit.transform != null && hit.transform.GetComponentInParent<PlayerController>() != null && Vector3.Distance(PlayerController.Instance.transform.position, transform.position) < Range)
        {
            ProjectileSpawner.ToFollow = null;
            if (justFound)
            {
                justFound = false;
                SoundController.PlaySound(Clips[Random.Range(0, Clips.Length)], false);
            }
            LookAt(player.transform.position);
            if ((activeAnimation != FireAnimation && activeAnimation != LookAnimation && Vector3.Distance(player.transform.position, transform.position) > StartAttackRange) ||
                ((activeAnimation == FireAnimation || activeAnimation == LookAnimation) && Vector3.Distance(player.transform.position, transform.position) > AttackRange))
            {
                rigidbody.velocity = transform.forward * Speed;
                if (!WalkAnimation.Active)
                {
                    activeAnimation.Active = false;
                    activeAnimation = WalkAnimation;
                    WalkAnimation.Activate(true);
                }
            }
            else
            {
                if (activeAnimation != FireAnimation && activeAnimation != LookAnimation)
                {
                    activeAnimation.Active = false;
                    activeAnimation = LookAnimation;
                    LookAnimation.Activate(true);
                }
                else if (activeAnimation == LookAnimation && !LookAnimation.Active)
                {
                    activeAnimation.Active = false;
                    activeAnimation = FireAnimation;
                    FireAnimation.Activate(true);
                }
            }
        }
        else
        {
            justFound = true;
            rigidbody.velocity = Vector3.zero;
            if (!IdleAnimation.Active)
            {
                activeAnimation.Active = false;
                activeAnimation = IdleAnimation;
                IdleAnimation.Activate(true);
            }
        }
    }
    private void LookAt(Vector3 pos)
    {
        transform.LookAt(pos - new Vector3(0, pos.y - transform.position.y));
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponentInParent<PlayerController>();)
    //}
}
