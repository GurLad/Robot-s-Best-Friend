using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SavedData;

public class PlayerController : MonoBehaviour
{
    public static Vector3 StartPos = new Vector3(-42.6f, 0, -45);
    public static PlayerController Instance;
    [Header("Stats")]
    public float Speed;
    public float Sensitivity;
    public float DashSpeed;
    public float DashEnergyRate;
    public float EnergyRecoverRate;
    [Header("Animations")]
    public AdvancedAnimation WalkAnimation;
    public AdvancedAnimation IdleAnimation;
    public AdvancedAnimation DashAnimation;
    [Header("Objects")]
    public GameObject Model;
    public Healthbar Energy;
    private Rigidbody rigidbody;
    private AdvancedAnimation activeAnimation;
    private bool dashing;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        transform.position = StartPos;
        rigidbody = GetComponent<Rigidbody>();
        activeAnimation = IdleAnimation;
        Energy.Max = 100;
        Energy.Value = 100;
        if (Load<int>("Difficulty") == 0)
        {
            DashEnergyRate /= 2;
        }
    }
    private void Update()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (targetVelocity.magnitude >= 1 / Sensitivity)
        {
            Model.transform.LookAt(Model.transform.position + targetVelocity);
            if (Input.GetButton("Dash") && Energy.Value > (dashing ? 0 : 10))
            {
                dashing = true;
                Energy.Value -= Time.deltaTime * DashEnergyRate;
                targetVelocity *= DashSpeed;
                if (!DashAnimation.Active)
                {
                    activeAnimation.Active = false;
                    activeAnimation = DashAnimation;
                    DashAnimation.Activate(true);
                }
            }
            else
            {
                dashing = false;
                targetVelocity *= Speed;
                if (!WalkAnimation.Active)
                {
                    activeAnimation.Active = false;
                    activeAnimation = WalkAnimation;
                    WalkAnimation.Activate(true);
                }
            }
        }
        else
        {
            targetVelocity = Vector3.zero;
            if (!IdleAnimation.Active)
            {
                activeAnimation.Active = false;
                activeAnimation = IdleAnimation;
                IdleAnimation.Activate(true);
            }
        }
        if (!dashing)
        {
            Energy.Value += Time.deltaTime * EnergyRecoverRate;
            if (Energy.Value >= 100)
            {
                Energy.Value = 100;
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
