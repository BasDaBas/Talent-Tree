using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;
    public Transform posToCastRay;

    public Interactable focus;	// Our current In range: Item, Enemy etc.

    public LayerMask movementMask;      // The ground
    public LayerMask interactionMask;	// Everything we can interact with

    //private Camera cam;				// Reference to our camera

    // Use this for initialization
    void Start ()
    {
        //cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())        
            return;


        //If press E
        if (Input.GetKeyDown(KeyCode.E))
        {
            //We create a ray
            RaycastHit hit;
            //if the ray hits
            Debug.DrawRay(posToCastRay.position, transform.TransformDirection(Vector3.forward), Color.green);
            if (Physics.Raycast(posToCastRay.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, interactionMask))
            {
                float radius = hit.transform.GetComponent<Interactable>().radius;
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance <= radius)
                {
                    Debug.Log("Hit " + hit.transform.name);
                    SetFocus(hit.collider.GetComponent<Interactable>());
                }
            }
            else
                Debug.Log("Didnt hit anything");
        }
	}
    //Can be used for Items, enemies etc.
    void SetFocus(Interactable newFocus)
    {
        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(newFocus);

        // If our focus has changed(item/enemy etc.)
        if (focus != newFocus && focus != null)
        {
            // Let our previous focus know that it's no longer being focused
            focus.OnDefocused();
        }

        // Set our focus to what we hit
        // If it's not an interactable, simply set it to null
        focus = newFocus;

        if (focus != null)
        {
            // Let our focus know that it's being focused
            focus.OnFocused(transform);
        }
    }

    
}
