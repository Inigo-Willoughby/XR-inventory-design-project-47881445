using UnityEngine;
using UnityEngine.InputSystem;

public class FlatInventory : InventoryMaster
{
    public GameObject UIPivot;
    private Quaternion currPlayerRotation;
    [SerializeField] private Camera headset;

    private InputAction inventoryButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currPlayerRotation = Quaternion.Euler(0, headset.transform.eulerAngles.y, 0);
    }

    private void OnEnable()
    {
        inventoryButton = ActionMap.FindAction("Toggle Inventory", false);
        if(inventoryButton != null)
        {
            inventoryButton.Enable();
            inventoryButton.performed += ToggleMenu;
        }
    }

    private void OnDisable()
    {
        if(inventoryButton != null) {inventoryButton.Disable();}
    }

    private void ToggleMenu(InputAction.CallbackContext ctx)
    {
        isActive = !isActive;
        showMenu(isActive);
        if(isActive)
        {
            currPlayerRotation = Quaternion.Euler(0, headset.transform.eulerAngles.y, 0);
            UIPivot.transform.rotation = currPlayerRotation;
        }
    }

    /*private void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(item.prefab, slot.transform.position);
    }*/

    /*add item void:
    if(!selectedInventoryTab.InventorySlot.checkIfEmpty){ return };
    check if there is an item in the player's hand
    add item to that tab
    selectedInventoryTab.InventorySlot.addItem(currentItem);
    clearPlayerHand();
    */

    /*remove item void
    if(selectedInventoryTab.InventorySlot.checkIfEmpty){ return };
    get item from selected tab
    spawn that item
    clear the tab  
    */

    //void for crafting item

    //open inventory
    /*
        button press
        stop UIPivot from following player all the time
        
    */
    //close inventory
    //resume UIPivot following player head position
    //base.start

    //check for free tab
    //check if tab is occupied
}
