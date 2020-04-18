﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [Header("Stats")]
    public float Speed;
    public float Sensitivity;
    [Header("Animations")]
    public AdvancedAnimation WalkAnimation;
    public AdvancedAnimation IdleAnimation;
    [Header("Objects")]
    public GameObject Model;
    private Rigidbody rigidbody;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (targetVelocity.magnitude >= 1 / Sensitivity)
        {
            Model.transform.LookAt(Model.transform.position + targetVelocity);
            targetVelocity *= Speed;
            if (!WalkAnimation.Active)
            {
                IdleAnimation.Active = false;
                WalkAnimation.Activate(true);
            }
        }
        else
        {
            targetVelocity = Vector3.zero;
            if (!IdleAnimation.Active)
            {
                WalkAnimation.Active = false;
                IdleAnimation.Activate(true);
            }
        }
        targetVelocity.y = rigidbody.velocity.y;
        rigidbody.velocity = targetVelocity;
    }
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
