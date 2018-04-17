using UnityEngine;

public class ItemPickUP : Interactable {

    public Item item;
    Inventory inventory;

    public void Start()
    {
        inventory = Inventory.instance;
    }

    //Every override function Interact will be called when its called from Script: Interactable.
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.instance.Add(item);


        Destroy(gameObject);         
        
    }
}
