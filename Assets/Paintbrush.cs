using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : MonoBehaviour
{
    public string triggerName;

    private Color currentColor;
    private bool triggerPressed;
    public GameObject strokePrefab;
    private LineRenderer currentStroke;
    private bool painting;
    private List<Vector3> segmentPositions = new List<Vector3>();
    private Vector3 lastSegmentPosition;
    public float segmentDistance;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetAxis(triggerName) > 0.5f && !triggerPressed)
        {
            triggerPressed = true;
            Debug.Log("Trigger pressed");

            StartStroke();
        }
        else if(Input.GetAxis(triggerName) < 0.5f && triggerPressed)
        {
            triggerPressed = false;
            Debug.Log("Trigger released");

            StopStroke();
        }

        if(painting)
        {
            // Has the paintbrush moved enought to add a new segment?
            if(Vector3.Distance(lastSegmentPosition, transform.position) > segmentDistance)
            {
                lastSegmentPosition = transform.position;

                // Create a new segment
                segmentPositions.Add(transform.position);

                // Update the stroke
                UpdateStroke();
            }

            // Update the last segment's position to the position of the paintbrush
        }
    }

    private void StartStroke()
    {
        currentStroke = Instantiate(strokePrefab).GetComponent<LineRenderer>();
        currentStroke.material.color = currentColor;

        // Grab the starting position of the stroke
        var startingPosition = transform.position;

        painting = true;
        segmentPositions.Clear();
        segmentPositions.Add(startingPosition);

        UpdateStroke();

        // Update the last segment's position in the line
        lastSegmentPosition = startingPosition;
    }
    private void StopStroke()
    {
        painting = false;
    }

    private void UpdateStroke()
    {
        currentStroke.positionCount = segmentPositions.Count;
        currentStroke.SetPositions(segmentPositions.ToArray());
    }

    private void OnTriggerEnter(Collider other)
    {
        var swatch = other.GetComponent<ColorSwatch>();
        if(swatch != null)
        {
            SetColor(swatch.color);
        }
    }

    private void SetColor(Color color)
    {
        currentColor = color;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
