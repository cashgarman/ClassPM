using System.Collections.Generic;
using UnityEngine;

public class StrokePainter : MonoBehaviour
{
    public LineRenderer strokePrefab;
    public string triggerName;
    public float segmentLength = 0.01f;

    private bool triggerHeld;
    private MeshRenderer handMesh;
    // private Color originalColor;
    private bool painting;
    private LineRenderer currentStroke;
    private Vector3 lastSegmentPosition;
    private List<Vector3> segmentPositions = new List<Vector3>();
    private Color currentColor;
   
    // public BoxCollider gameArea;

    void Start()
    {
	    handMesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
	    if (Input.GetAxis(triggerName) > 0.8f && !triggerHeld)
	    {
		    triggerHeld = true;

		    StartStroke();
	    }
	    else if (Input.GetAxis(triggerName) < 0.8f && triggerHeld)
	    {
		    triggerHeld = false;

		    StopStroke();
	    }
	    
	    // If we're painting a stroke
	    if (painting)
	    {
		    // If the new position of the hand is greater than the stroke's segment length
		    if (Vector3.Distance(transform.position, lastSegmentPosition) >= segmentLength)
		    {
			    Debug.Log($"Adding a new segment");
			    
			    // Add a new segment to the stroke at the current position
			    segmentPositions.Add(transform.position);
			    
			    // Update the last segment's position in the line
			    lastSegmentPosition = transform.position;
			    
			    UpdateStroke();
		    }

		    // Update the end position of the stroke
		    currentStroke.SetPosition(segmentPositions.Count - 1, transform.position);
	    }
    }

    public void StartStroke()
    {
	    Debug.Log($"Starting Stroke");
	    
	    // Create a new line
	    currentStroke = Instantiate(strokePrefab);
	    currentStroke.material.color = currentColor;
		    
	    // Grab the starting position of the stroke
	    var startingPosition = transform.position;
		    
	    // Start painting a new stroke
	    painting = true;
	    segmentPositions.Clear();
	    segmentPositions.Add(startingPosition);
		    
	    // Update the stroke
	    UpdateStroke();
		    
	    // Update the last segment's position in the line
	    lastSegmentPosition = startingPosition;
    }

    public void StopStroke()
    {
	    Debug.Log($"Stopping Stroke");
	    
	    // Stop painting a stroke
	    painting = false;
    }

    private void UpdateStroke()
    {
	    currentStroke.positionCount = segmentPositions.Count;
	    currentStroke.SetPositions(segmentPositions.ToArray());
    }

    public void SetColor(Color color)
    {
	    currentColor = color;
	    handMesh.material.color = color;
    }
}
