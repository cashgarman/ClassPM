using UnityEngine;

public class PaintbrushHand : MonoBehaviour
{
    public string triggerName;

    private MeshRenderer handMesh;
    private bool triggerHeld;
    private Color originalColor;
    private GameObject selectedObject;
    private Material selectedObjectMaterial;
    private Color selectedObjectOriginalColor;
    // private GameObject grabbedObject;
    private FixedJoint fixedJoint;
    
    private Animator animator;
    public string holdTriggerName;

    private void Start()
    {
        // handMesh = GetComponent<MeshRenderer>();
        // fixedJoint = GetComponent<FixedJoint>();
        // originalColor = handMesh.material.color;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
	    Debug.Log($"Input.GetAxis(triggerName): {Input.GetAxis(triggerName)}");
	    
	  //   if(Input.GetAxis(triggerName) > 0.8f && !triggerHeld)
	  //   {
			// triggerHeld = true;
			// handMesh.material.color = Color.green;
	  //
			// if (selectedObject != null)
			// {
			// 	// fixedJoint.connectedBody = selectedObject.GetComponent<Rigidbody>();
			// 	selectedObject.transform.SetParent(transform);
			// 	selectedObject.GetComponent<Rigidbody>().isKinematic = true;
			// }
	  //   }
	  //   else if(Input.GetAxis(triggerName) < 0.8f && triggerHeld)
	  //   {
		 //    triggerHeld = false;
		 //    handMesh.material.color = originalColor;
		 //    
		 //    if (selectedObject != null)
		 //    {
			//     // fixedJoint.connectedBody = null;
			//     selectedObject.GetComponent<Rigidbody>().isKinematic = false;
			//     selectedObject.transform.SetParent(null);
		 //    }
	  //   }
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
