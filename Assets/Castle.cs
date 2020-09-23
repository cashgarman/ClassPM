using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float health;
    public TMP_Text healthLabel;

    private void Update()
    {
        healthLabel.text = $"Heath: {health}";
    }
}
