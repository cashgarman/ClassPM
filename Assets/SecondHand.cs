using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHand : MonoBehaviour
{
    public Clock clock;

    public void OnMinutePassed()
    {
        clock.OnMinutePassed();
    }
}
