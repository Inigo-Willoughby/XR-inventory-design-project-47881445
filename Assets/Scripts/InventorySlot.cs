using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    public ItemData itemInSlot;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI slotText;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnSlotClicked);
        slotText = this.GetComponentInChildren<TextMeshProUGUI>();
        if(slotText!=null)
        {
            slotText.text = "";
        }
    }

    public void interactWithSlot(PlayerHand hand)
    {
        if(checkIfEmpty())
        {
            tryAddItem(hand);
        }
        else
        {
            tryRemoveItem(hand);
        }
    }

    private void OnSlotClicked()
    {
        Debug.Log("Clicked");
    }

    //try and add item to slot
    private void tryAddItem(PlayerHand hand)
    {
        if(hand == null ||hand.itemInHand == null) { return; }

        ItemData newItem = hand.itemInHand.data;

        updateSlot(newItem);

        hand.RemoveItem();
    }

    //try and remove item from slot
    private void tryRemoveItem(PlayerHand hand)
    {
        /*if(hand == null || this.itemInSlot==null) { return; }

        ItemData currItem = this.itemInSlot;

        if(hand.itemInHand!=null) 
        {
            Debug.Log("Item already in hand!");
        }
        else
        {
            Debug.Log("Trying to remove item");
            updateSlot(null);
            var newItem = Instantiate(currItem);
            currItem.pickUp(hand);
        }
        Debug.Log("trying to remove item to " + hand);*/
    }

    private void updateSlot(ItemData newItem)
    {
        this.itemInSlot = newItem;
        if(newItem!=null)
        {
            slotText.text = itemInSlot.itemName;
        }
        else
        {
            slotText.text = "";
        }
    }

    public void ClearSlot()
    {
        updateSlot(null);
    }

    private bool checkIfEmpty()
    {
        return itemInSlot==null;
    }
}
