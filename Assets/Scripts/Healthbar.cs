using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public string Name;
    public Color Color;
    public Text Text;
    public Image ValueImage;
    public Image MaxImage;
    [HideInInspector]
    public float Max;
    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            ValueImage.rectTransform.sizeDelta = new Vector2(MaxImage.rectTransform.sizeDelta.x * (value / Max), MaxImage.rectTransform.sizeDelta.y);
        }
    }
    private float value;
    private void Start()
    {
        Text.text = Name;
        ValueImage.color = Color;
    }
}
