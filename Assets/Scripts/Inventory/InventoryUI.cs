using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This object updates the inventory UI. */
public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;                   // The parent object of all the items
    public GameObject inventoryUI;	                // The entire UI
    public PlayerMovement playerMovementScript;     // The playerMovementScript
    public PlayerCamera playerCameraMovement;     // The CameraMovementScript

    Inventory inventory;                // Our current inventory

    InventorySlot[] slots;              // List of all the slots


    // Use this for initialization
    void Start () {

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;        // Subscribe to the onItemChanged callback
        
        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        //set false after it  has the instance otherwise it bugs out.
        inventoryUI.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            playerMovementScript.enabled = !inventoryUI.activeSelf;
            playerCameraMovement.enabled = !inventoryUI.activeSelf;
        }
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
