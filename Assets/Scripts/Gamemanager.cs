using UnityEngine;
using UnityEngine.XR;

public class Gamemanager : MonoBehaviour
{
    void Start()
    {
        XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
    }
}