using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    [SerializeField]
    private Text m_countDisplay;

    [HideInInspector]
    public int m_count;

    public void UpdateDisplay()
    {
        m_countDisplay.text = "Shots Fired: " + m_count;
    }
}
