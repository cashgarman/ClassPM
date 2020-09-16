using UnityEngine;
using Vuforia;

public class Piano : MonoBehaviour
{
    public VirtualButtonBehaviour[] virtualButtons;
    
    void Start()
    {
        foreach(var virtualButton in virtualButtons)
        {
            virtualButton.RegisterOnButtonPressed(OnKeyPressed);
            virtualButton.RegisterOnButtonReleased(OnKeyReleased);
            virtualButton.UpdateSensitivity();
        }
    }

    private void OnKeyPressed(VirtualButtonBehaviour button)
    {
        button.GetComponent<PianoKey>().OnPressed();
    }
    
    private void OnKeyReleased(VirtualButtonBehaviour button)
    {
        button.GetComponent<PianoKey>().OnReleased();
    }
}