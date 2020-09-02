using UnityEngine;

public class MinuteHand : MonoBehaviour
{
    public void OnAdvance()
    {
        transform.Rotate(0, 0, -360f / 60f);
    }
}
