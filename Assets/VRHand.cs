using System;
using UnityEngine;

public class VRHand : MonoBehaviour
{
    public string triggerName;

    private MeshRenderer handMesh;
    private bool triggerHeld;
    private Color originalColor;
    private GameObject selectedObject;
    private Material selectedObjectMaterial;
    private Color selectedObjectOriginalColor;

    private void Start()
    {
        handMesh = GetComponent<MeshRenderer>();
        originalColor = handMesh.material.color;
    }

    void Update()
    {
	    if(Input.GetAxis(triggerName) > 0.8f && !triggerHeld)
	    {
			triggerHeld = true;
			handMesh.material.color = Color.green;
	    }
	    else if(Input.GetAxis(triggerName) < 0.8f && triggerHeld)
	    {
		    triggerHeld = false;
		    handMesh.material.color = originalColor;
	    }
    }

    private void OnTriggerEnter(Collider other)
    {
	    Debug.Log($"{name} entered the collider of {other.name}");
	    selectedObjectMaterial = other.GetComponent<MeshRenderer>().material;
	    selectedObjectOriginalColor = selectedObjectMaterial.color;
	    selectedObjectMaterial.color = Color.red;
	    selectedObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
	    if (selectedObject != null)
	    {
		    other.GetComponent<MeshRenderer>().material.color = selectedObjectOriginalColor;
	    }
    }
}
