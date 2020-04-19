using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Healthbar Healthbar;
    public bool IsEnemy;
    public float HP;
    public bool Rat = true;
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
    private void OnTriggerEnter(Collider other)
    {
        Damage damage = other.gameObject.GetComponentInParent<Damage>();
        if (damage != null)
        {
            Debug.Log(gameObject.name + " was hit");
            if (IsEnemy != damage.IsEnemy)
            {
                HP -= damage.Amount;
                //damage.Amount = 0;
                if (HP <= 0)
                {
                    if (IsEnemy)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        PlayerController.Instance.Lose(Rat);
                    }
                }
                Destroy(other.transform.parent.gameObject);
                if (Healthbar != null)
                {
                    Healthbar.Value = HP;
                }
            }
        }
    }
}
