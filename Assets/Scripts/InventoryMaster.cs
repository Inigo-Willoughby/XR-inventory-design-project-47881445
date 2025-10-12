using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InventoryMaster : MonoBehaviour
{
    public GameObject InventoryObject;
    [SerializeField] protected bool isActive = false;
    [HideInInspector] public bool IsActive { get => isActive;}
    [SerializeField] protected InputActionAsset ActionMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showMenu(false);
        isActive = false;
    }

    protected void showMenu(bool state)
    {
        InventoryObject.SetActive(state);
    }

    public void addItem()
    {
        Debug.Log("Adding Item");
        //Get hand that pressed it
        //see if it has an item in it
        //debug if it has an item, debug if not
    }

    //check for available tab
    //check if tab is occupied

    //template for adding item //flat = trigger, dynamic = place in inventory slot collider
    //template for removing item //flat = click on tab in inventory, dynamic = grab from inventory
    //template for crafting coroutine
    /*
        get item1
        if(item2 == item1.other){
            craft item1.result;
        }
    */

    //template for opening inventory //flat=button press, dynamic = reach behind back
    /*

    */
    //template for closing inventory //flat=button press, dynamic = let go
    /*
        InventoryObject.SetActive(isActive);
    */
}
