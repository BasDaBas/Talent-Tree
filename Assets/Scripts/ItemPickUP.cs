using UnityEngine;

public class ItemPickUP : Interactable {

    public Item item; // Item to put in the inventory on pickup

    //Every override function Interact will be called when its called from Script: Interactable.
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Inventory.instance.Add(item);       // Add to inventory
        // If successfully picked up
        Destroy(gameObject);         
        
    }
}
