using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
	public MinuteHand minuteHand;

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

	public void OnMinutePassed()
	{
		minuteHand.OnAdvance();
	}
}
