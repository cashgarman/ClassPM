using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light m_light;

    private void Start()
    {
        m_light.enabled = false;
    }

    void TriggerDown()
    {
        m_light.enabled = !m_light.enabled;
    }
}