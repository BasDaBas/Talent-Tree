using UnityEngine;

public class ItemPickUP : Interactable {

    public Item item;

    public void Start()
    {

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
        Debug.Log(Inventory.instance.Add(item));
        Inventory.instance.Add(item);

        Destroy(gameObject);         
        
    }
}
