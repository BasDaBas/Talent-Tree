using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class InventorySlot : MonoBehaviour, IPointerClickHandler
{   

    Item item;
    public Button invButton;

    public Image icon;
    public Sprite defaultIcon;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.Icon;
        invButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = defaultIcon;
        invButton.interactable = false;
    }

    public void RemoveItem()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            RemoveItem();
        }
    }


}
