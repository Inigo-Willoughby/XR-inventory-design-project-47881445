using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    public Item itemInSlot;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI slotText;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        slotText = this.GetComponentInChildren<TextMeshProUGUI>();
        if(slotText!=null)
        {
            slotText.text = "";
        }
    }

    private void tryAddItem(PlayerHand hand)
    {
        Debug.Log("trying to add item from " + hand);
        Item handItem = hand.itemInHand;
        Debug.Log(handItem);
        if(handItem==null) { return; }
        updateSlot(handItem);
        hand.RemoveItem();
    }

    private void tryRemoveItem(PlayerHand hand)
    {
        if(this.itemInSlot==null) { return; }

        Item slotItem = this.itemInSlot;

        if(hand.itemInHand!=null) 
        {
            Debug.Log("Item already in hand!");
        }
        else
        {
            Debug.Log("Trying to remove item");
            updateSlot(null);
            var newItem = Instantiate(slotItem);
            slotItem.pickUp(hand);
        }
        Debug.Log("trying to remove item to " + hand);
    }

    private void updateSlot(Item newItem)
    {
        itemInSlot = newItem;
        if(newItem!=null)
        {
            slotText.text = newItem.prefab.name;
        }
        else
        {
            slotText.text = "";
        }
    }

    public void interactWithSlot(PlayerHand hand)
    {
        Debug.Log("Interacting with slot");
        if(checkIfEmpty())
        {
            Debug.Log("SLOT IS EMPTY");
            tryAddItem(hand);
        }
        else
        {
            Debug.Log("SLOT HAS ITEM");
            tryRemoveItem(hand);
        }
    }

    private bool checkIfEmptyHand(PlayerHand hand)
    {
        return hand.itemInHand == null;
    }

    private bool checkIfEmpty()
    {
        return itemInSlot==null;
    }
}
