using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SavedData;

public class ChangeDifficulty : MonoBehaviour
{
    public Text Display;
    private void Start()
    {
        Display.text = Load<int>("Difficulty") == 0 ? "Difficulty: Normal" : "Difficulty: Hard";
    }
    public void Click()
    {
        Save("Difficulty", 1 - Load<int>("Difficulty"));
        Display.text = Load<int>("Difficulty") == 0 ? "Difficulty: Normal" : "Difficulty: Hard";
    }
}
