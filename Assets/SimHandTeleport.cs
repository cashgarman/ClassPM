using UnityEngine;

public class SimHandTeleport : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private bool foundPosition;
    private Vector3 teleportPosition;
    public Transform simHead;
    public Vector3 playerHeight;

    void Update()
    {
        // If the right mouse button pressed
        if (Input.GetMouseButton(1))
        {
            // Use a raycast to see if the hand is pointing at anything
            if(Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                // If so, setup the line renderer to show a line to the target position
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
                
                // Show the line
                lineRenderer.enabled = true;
                
                // Store the teleport position
                foundPosition = true;
                teleportPosition = hit.point;
            }
            // If the raycast didn't hit anything
            else
            {
                // Hide the line renderer
                lineRenderer.enabled = false;
                
                // Remember we haven't a location to teleport to
                foundPosition = false;
            }
        }
        // If the left mouse button isn't being pressed
        else
        {
            // Hide the teleport line
            lineRenderer.enabled = false;

            // If we had previously found a valid location to teleport to
            if (foundPosition)
            {
                // Move the simulated VR head to the found teleport position (taking into account the height of the player) 
                simHead.position = teleportPosition + playerHeight;
                
                // Reset the found teleport position so we don't keep warping to this position every frame
                foundPosition = false;
            }
        }
    }
}
