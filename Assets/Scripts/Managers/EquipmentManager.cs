using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    
    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    
    Equipment[] currentEquipment; //items we currently have
    
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;     // Get a reference to our inventory

        // Initialize currentEquipment based on number of equipment slots
        int numSlots = System.Enum.GetNames(typeof(Equipment.EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    // Equip a new item
    public void Equip(Equipment newItem)
    {
        //Find out what slot the item fits in
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = UnEquip(slotIndex);       

        //An item has been equipped so we trigger the callback
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;  
        
        //SetEquipmentBlendShapes(newItem, 1);        
        //insert the item into the slot
        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;

        //Todo Update player stats
        
    }
    //Unequip Gear
    public Equipment UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {            
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            
            // EquipDefaultItems();           

            //Add item to the inventory
            Equipment oldItem = currentEquipment[slotIndex];
            //SetEquipmentBlendShapes(oldItem, 0);
            inventory.Add(oldItem);
            //remove the item from the equipment array;
            currentEquipment[slotIndex] = null;
            //equipment has been removed so we trigger the callback
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
        
    }
    //Unequip All gear
    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
        EquipDefaultItems();
    }

    //character has no blendshapes so we  cant use this.
    /*void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (Equipment.EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            Debug.Log((int)blendShape);
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }*/
    //Equip the default items of the character
    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item); 
        }
    }

    void UpdatePlayerStats()
    {


    }

    //Unequip all
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))        
            UnEquipAll();        
    }
}
