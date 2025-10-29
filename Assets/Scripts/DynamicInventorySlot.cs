using UnityEngine;

public class DynamicInventorySlot : Slot
{
    [SerializeField] private Item currItem;
    [HideInInspector] public Item CurrItem{ get => currItem; }

    //try and add item to slot
    public void AddItem(Item item)
    {
        itemInSlot = item.data;
        currItem = item;
    }

    public void RemoveItem()
    {
        itemInSlot = null;
        currItem = null;
    }
}
