using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayerHand : MonoBehaviour
{
    public Item itemInHand;
    private NearFarInteractor raycast;
    public NearFarInteractor Raycast { get => raycast; }

    [SerializeField] private InputActionAsset ActionMap;
    private InputAction triggerButton;
    [SerializeField] private bool isFlatScreenMode = true;
    [HideInInspector] public bool IsFlatScreenMode { get => isFlatScreenMode; }

    void OnEnable()
    {
        if(raycast==null)
        {
            raycast = GetComponentInChildren<NearFarInteractor>();
        }

        XRInteractionGroup inGroup = GetComponent<XRInteractionGroup>();

        triggerButton = ActionMap.FindAction("Trigger"+inGroup.groupName, true);
        if(triggerButton!=null)
        {
            triggerButton.Enable();
            triggerButton.performed += TriggerEvent;
        }
    }

    void OnDisable()
    {
        if (triggerButton != null)
        {
            triggerButton.performed -= TriggerEvent;
            triggerButton.Disable();
        }
    }

    //add item to hand from inventory
    public void AddItem(Item addedItem)
    {
        if(addedItem == null) { return; }
        if(this.itemInHand==null)
        {
            itemInHand = addedItem;
        }
        else
        {
            Debug.Log("Item already in hand");
        }
    }

    public void DropItem()
    {
        if(itemInHand!=null)
        {
            itemInHand = null;
        }
    }

    //remove item from hand
    public void RemoveItem()
    {
        if(itemInHand!=null)
        {
            Destroy(itemInHand.gameObject);
            itemInHand = null;
        }
    }

    private void TriggerEvent(InputAction.CallbackContext context)
    {
        if(isFlatScreenMode){
            if(raycast==null){ return; }
            if(raycast.TryGetCurrentUIRaycastResult(out RaycastResult RayCastResult))
            {
                Debug.Log(RayCastResult);
                InventorySlot slot = RayCastResult.gameObject.GetComponentInParent<InventorySlot>();
                if(slot!=null)
                {
                    slot.interactWithSlot(this);
                }
            }
        }
    }
}
