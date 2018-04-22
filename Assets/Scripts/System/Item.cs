using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* The base item class. All items should derive from this. */


[CreateAssetMenu(fileName = "New Item" , menuName = "Inventory/Item")]
public class Item : ScriptableObject {
        
    [SerializeField] string itemName;               // Name of the item
    [SerializeField] string description;	        // Item Description
    [SerializeField] Sprite icon;                   // Item icon
    [SerializeField] ItemType itemType;             //Item type
    [SerializeField] bool isDefaultItem = false;    // Is the item default wear?

    public string Name
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public ItemType Type
    {
        get { return itemType; }
    }

    public bool IsDefaultItem
    {
        get { return isDefaultItem; }
        set { isDefaultItem = value; }
    }

    public virtual void Use()
    {
        //use the item
        //something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    //Effect / Buffs   

}
