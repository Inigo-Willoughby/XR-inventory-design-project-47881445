using UnityEngine;

public class DynamicInventorySlot : MonoBehaviour
{
    public ItemData itemInSlot;

    //try and add item to slot
    public void AddItem(Item item)
    {
        itemInSlot = item.data;
    }

    public void RemoveItem()
    {
        itemInSlot = null;
    }
}
