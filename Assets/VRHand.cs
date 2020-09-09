using UnityEngine;

public class VRHand : MonoBehaviour
{
    public string triggerName;

    private bool triggerHeld;
    private Color originalColor;
    private GameObject highlightedObject;
    private Material selectedObjectMaterial;
    private Color selectedObjectOriginalColor;
    private Animator animator;
    private GameObject heldObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
	    if(Input.GetAxis(triggerName) > 0.8f && !triggerHeld)
	    {
			triggerHeld = true;
			animator.SetTrigger("Grip");

			if (highlightedObject != null)
			{
				GrabHighlightedObject();
			}
	    }
	    else if(Input.GetAxis(triggerName) < 0.8f && triggerHeld)
	    {
		    triggerHeld = false;
		    animator.SetTrigger("Ungrip");
		    
		    if (heldObject != null)
		    {
			    DropHeldObject();
		    }
	    }
    }

    private void GrabHighlightedObject()
    {
	    Debug.Log($"Grabbing {highlightedObject.name}");
	    highlightedObject.GetComponent<Rigidbody>().isKinematic = true;
	    highlightedObject.transform.SetParent(transform);
	    heldObject = highlightedObject;
    }

    private void DropHeldObject()
    {
	    Debug.Log($"Dropping {heldObject.name}");
	    heldObject.GetComponent<Rigidbody>().isKinematic = false;
	    heldObject.transform.SetParent(null);
	    heldObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
	    if (heldObject != null)
	    {
		    return;
	    }

	    HighlightObject(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
	    Debug.Log($"{name} left the collider of {other.name}");
	    UnhighlightObject(other.gameObject);
    }

    private void HighlightObject(GameObject obj)
    {
	    Debug.Log($"{name} entered the collider of {obj.name}");
	    selectedObjectMaterial = obj.GetComponent<MeshRenderer>().material;
	    selectedObjectOriginalColor = selectedObjectMaterial.color;
	    selectedObjectMaterial.color = Color.red;
	    highlightedObject = obj.gameObject;
    }

    private void UnhighlightObject(GameObject obj)
    {
	    obj.GetComponent<MeshRenderer>().material.color = selectedObjectOriginalColor;
    }
}
