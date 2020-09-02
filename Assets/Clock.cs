using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform minuteHand;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 20f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    internal void OnMinutePassed()
    {
        minuteHand.Rotate(0, 0, -360f / 60f);
    }
}
