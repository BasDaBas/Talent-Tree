using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats {

    //Get the UI Components;
    public Text attributeText;
    public Text attributeAmount;

    // Use this for initialization
    void Start ()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

    private void Update()
    {
        
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            List<Stat>.Enumerator PlayerAttr = stats.GetEnumerator();
            //List<Stat>.Enumerator EquipmentAttr = newItem.equipmentStats.GetEnumerator();
            while (PlayerAttr.MoveNext())
            {
                foreach (Stat equipmentAttr in newItem.equipmentStats)
                {
                    if (equipmentAttr.StatName == PlayerAttr.Current.StatName)
                    {
                        attributeAmount.text = PlayerAttr.Current.ToString();
                    }
                }
                
            }
            
            
        }
        if (oldItem != null)
        {
            foreach (Stat stat in stats)
            {
                stat.RemoveModifier(oldItem.armorModifier);
            }
        }
        
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
