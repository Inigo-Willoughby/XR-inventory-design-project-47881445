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
        if(handItem==null) { return; }
        addItem(handItem);
        hand.RemoveItem();
    }

    private void addItem(Item newItem)
    {
        itemInSlot = newItem;
        slotText.text = itemInSlot.prefab.name;      
    } 

    private void tryRemoveItem(PlayerHand hand)
    {
        if(this.itemInSlot==null) { return; }
        if(hand.itemInHand!=null) { return; }
        Debug.Log("trying to remove item to " + hand);
        //remove item from inventory slot
        //removeItem(item);
    }

    private void removeItem()
    {
        //add item to player's hand
    }

    public void interactWithSlot(PlayerHand hand)
    {
        Debug.Log("clicked with " + hand);
        //get whichever hand interacted with the button
        if(checkIfEmpty())
        {
            tryAddItem(hand);
        }
        else
        {
            tryRemoveItem(hand);
        }
    }

    private bool checkIfEmpty()
    {
        return itemInSlot==null;
    }
}
