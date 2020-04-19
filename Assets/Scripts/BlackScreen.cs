﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public float Speed = 1;
    public static bool Finished = true;
    private static BlackScreen instance;
    private Image image;
    private bool shouldBeOn;
    private Color color;
    private void Awake()
    {
        instance = this;
        Finished = true;
        image = GetComponent<Image>();
        color = image.color;
    }
    private void Update()
    {
        if (shouldBeOn)
        {
            if (color.a < 1)
            {
                Finished = false;
                color.a += Time.deltaTime * Speed;
                if (color.a >= 1)
                {
                    color.a = 1;
                    Finished = true;
                }
                image.color = color;
            }
        }
        else
        {
            if (color.a > 0)
            {
                Finished = false;
                color.a -= Time.deltaTime * Speed;
                if (color.a <= 0)
                {
                    color.a = 0;
                    Finished = true;
                }
                image.color = color;
            }
        }
    }
    public static void Set(bool on)
    {
        Finished = false;
        instance.shouldBeOn = on;
    }
}
