using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;   // Increase/decrease in armor
    public int damageModifier;  // Increase/decrease in damage

    // When pressed in inventory
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

    public enum EquipmentSlot { Head, Legs, Chest, Boots, Gloves, Weapon1, Weapon2, Shield}    
    public enum EquipmentMeshRegion {Legs, Arms, Torso};  //corrosponds to body blendshapes
    
	
}

