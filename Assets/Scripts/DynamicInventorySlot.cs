using UnityEngine;

public class DynamicInventorySlot : MonoBehaviour
{
    public ItemData itemInSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
