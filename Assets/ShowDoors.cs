using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDoors : MonoBehaviour
{
    [Range(0,1)]
    public float Percent;
    public GameObject[] Doors;
    private void Start()
    {
        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].SetActive(Random.Range(0f,1f) <= Percent);
        }
    }
}
