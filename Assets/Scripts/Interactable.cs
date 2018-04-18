using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/


public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;	    // Is this interactable currently being focused?
    Transform player;		    // Reference to the player transform
    public bool hasInteracted = false;	// Have we already interacted with the object?

    private void Update()
    {
        if (isFocus)    //If currently being in range
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (!hasInteracted && distance <= radius)
            {
                // Interact with the object
                hasInteracted = true;
                Debug.Log("Interact Calling");
                Interact();
            }
        }
    }

    // This method is meant to be overwritten
    public virtual void Interact()
    {
        Debug.Log("Virtual void Interact Called");
    }

    // Called when the object starts being focused
    public void OnFocused(Transform playerTransform)
    {
        Debug.Log("OnFocused Called");

        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    // Called when the object is no longer focused
    public void OnDefocused()
    {
        Debug.Log("OnDeFocused Called");

        isFocus = false;
        hasInteracted = false;
        player = null;
    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
