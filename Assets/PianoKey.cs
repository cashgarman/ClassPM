using UnityEngine;

public class PianoKey : MonoBehaviour
{
	public void OnPressed()
	{
		Debug.Log($"Pressed {name}");
	}

	public void OnReleased()
	{
		Debug.Log($"Released {name}");
	}
}