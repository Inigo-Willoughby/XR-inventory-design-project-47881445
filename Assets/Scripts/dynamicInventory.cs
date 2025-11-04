using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class dynamicInventory : InventoryMaster
{
    private InputAction gripButton;
    [SerializeField] private bool isHeld;
    [SerializeField] private bool holstered;
    private XRGrabInteractable grabInteractable; 
    
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
        showMenu(isHeld == false && holstered == false);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        SetRotation();
        showMenu(isHeld == false && holstered == false);
    }

    private void SetItemPhysics(bool state)
    {
        foreach(DynamicInventorySlot s in inventorySlots)
        {
            if(s.CurrItem!=null)
            {
                s.CurrItem.SetPhysics(state);
            }
        }   
    }

    private void SetRotation()
    {
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0.0f, currentEulerAngles.y, 0.0f);
    }
}
