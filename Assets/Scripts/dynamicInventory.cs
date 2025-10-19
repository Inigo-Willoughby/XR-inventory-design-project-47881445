using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class dynamicInventory : InventoryMaster
{
    private InputAction gripButton;
    [SerializeField] private bool isHeld;
    [SerializeField] private bool holstered;
    private XRGrabInteractable grabInteractable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created   
    
    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    void OnDisable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
        Debug.Log("released");
        showMenu(!isHeld);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        Debug.Log("released");
        showMenu(isHeld == false && holstered == false);
    }

    //showMenu(isHeld == false && holstered == false);
    
    //if grabbing while active
    ///disable Menu

    //void for adding item
    /*
        add image to slot
    */
    //void for removing item
    //void for crafting item

    //open inventory
    //move backpack pivot to player hand
    //base.start



    //close inventory
    //Move object back to anchor
    //base.start

    //check for free tab
    //check if tab is occupied
}
