﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RatMode { Inside, Outside, Running }
public class RatAI : MonoBehaviour
{
    public static RatAI Instance;
    [Header("Stats")]
    public float OxygenDecayRate;
    public float OxygenReplenishRate;
    public Vector2 TimeToFlee;
    [Header("Objects")]
    public Healthbar OxygenDisplay;
    public AdvancedAnimation OpenLidAnimation;
    public AdvancedAnimation CloseLidAnimation;
    public Collider Backpack; 
    public GameObject Body;
    public RatRunAI Rat;
    [HideInInspector]
    public RatMode Mode;
    private float oxygen;
    private float timeToFlee;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OxygenDisplay.Max = 100;
        OxygenDisplay.Value = 100;
        oxygen = 100;
        timeToFlee = Random.Range(TimeToFlee.x, TimeToFlee.y);
    }
    private void Update()
    {
        switch (Mode)
        {
            case RatMode.Inside:
                oxygen -= Time.deltaTime * OxygenDecayRate;
                if (oxygen <= 0)
                {
                    PlayerController.Instance.Lose();
                }
                OxygenDisplay.Value = oxygen;
                if (Input.GetButtonDown("OpenCloseLid"))
                {
                    OpenLid();
                }
                break;
            case RatMode.Outside:
                timeToFlee -= Time.deltaTime;
                if (timeToFlee <= 0)
                {
                    timeToFlee = Random.Range(TimeToFlee.x, TimeToFlee.y);
                    Mode = RatMode.Running;
                    Body.SetActive(false);
                    Backpack.enabled = false;
                    RatRunAI newRat = Instantiate(Rat.gameObject).GetComponent<RatRunAI>();
                    newRat.transform.position = PlayerController.Instance.transform.position - PlayerController.Instance.Model.transform.forward * 1.5f;
                    newRat.Velocity = -PlayerController.Instance.Model.transform.forward * newRat.Speed;
                    newRat.Start();
                }
                oxygen += Time.deltaTime * OxygenReplenishRate;
                if (oxygen >= 100)
                {
                    oxygen = 100;
                }
                OxygenDisplay.Value = oxygen;
                if (Input.GetButtonDown("OpenCloseLid"))
                {
                    CloseLid();
                }
                break;
            case RatMode.Running:
                oxygen += Time.deltaTime * OxygenReplenishRate;
                if (oxygen >= 100)
                {
                    oxygen = 100;
                }
                OxygenDisplay.Value = oxygen;
                break;
            default:
                break;
        }
    }
    public void OpenLid()
    {
        if (!OpenLidAnimation.Active)
        {
            CloseLidAnimation.Active = false;
            OpenLidAnimation.Activate(true);
        }
        Mode = RatMode.Outside;
    }
    public void CloseLid()
    {
        if (!CloseLidAnimation.Active)
        {
            OpenLidAnimation.Active = false;
            CloseLidAnimation.Activate(true);
        }
        Mode = RatMode.Inside;
    }
}
