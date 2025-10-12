using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    public Item itemInSlot;
    [SerializeField] private Button button;

    private void Awake()
    {
        button = this.GetComponent<Button>();
    }

    private void tryAddItem(PlayerHand hand)
    {
        Debug.Log("trying to add item from " + hand);
        //check if slot is empty
        //if(hand.itemInHand==null) { return; }
        //remove item from player's hand
        //addItem(item)
    }

    private void addItem(Item newItem)
    {
        //set itemInSlot to new item
        //add icon to slot visual      
    } 

    private void tryRemoveItem(PlayerHand hand)
    {
        Debug.Log("trying to remove item to " + hand);
        //check if slot has item
        //if(hand.itemInHand==null) { return; }
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
