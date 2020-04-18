using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Healthbar Healthbar;
    public bool IsEnemy;
    public float HP;
    public float InvincibilityTime;
    private float count = 0;
    private float fullSize;

    // Start is called before the first frame update
    void Start()
    {
        if (Healthbar != null)
        {
            Healthbar.Max = HP;
            Healthbar.Value = HP;
            Healthbar.ValueImage.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 0)
        {
            count -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Damage damage = other.gameObject.GetComponentInParent<Damage>();
        if (damage != null && count <= 0)
        {
            if (IsEnemy != damage.IsEnemy)
            {
                HP -= damage.Amount;
                if (HP <= 0)
                {
                    if (IsEnemy)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        PlayerController.Instance.Lose();
                    }
                }
                count = InvincibilityTime;
                Destroy(other.gameObject);
                if (Healthbar != null)
                {
                    Healthbar.Value = HP;
                }
            }
        }
    }
}
