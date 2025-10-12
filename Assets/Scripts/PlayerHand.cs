using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayerHand : MonoBehaviour
{
    public Item itemInHand;
    [SerializeField] private NearFarInteractor raycast;

    [SerializeField] private InputActionAsset ActionMap;
    private InputAction triggerButton;
    private InputAction gripButton;
    [SerializeField] private GameObject itemPoint;
    [HideInInspector] public GameObject ItemPoint { get => itemPoint; }
    [SerializeField] private bool isFlatScreenMode = true;
    [HideInInspector] public bool IsFlatScreenMode { get => isFlatScreenMode; }

    void OnEnable()
    {
        if(raycast==null)
        {
            raycast = GetComponentInChildren<NearFarInteractor>();
        }

        /*if(directInteractor==null)
        {
            directInteractor = GetComponentInChildren<DirectInteractor>();
        }*/

        XRInteractionGroup inGroup = GetComponent<XRInteractionGroup>();

        triggerButton = ActionMap.FindAction("Trigger"+inGroup.groupName, true);
        if(triggerButton!=null)
        {
            triggerButton.Enable();
            triggerButton.performed += TriggerEvent;
        }

        gripButton = ActionMap.FindAction("Grip"+inGroup.groupName, true);
        if(gripButton!=null)
        {
            gripButton.Enable();
            gripButton.started += GripStarted;
            gripButton.performed += GripPerformed;
            gripButton.canceled += GripCanceled;
        }
    }

    void OnDisable()
    {
        if (triggerButton != null)
        {
            triggerButton.performed -= TriggerEvent;
            triggerButton.Disable();
        }
        if(gripButton != null)
        {
            gripButton.Disable();
            gripButton.started -= GripStarted;
            gripButton.performed -= GripPerformed;
            gripButton.canceled -= GripCanceled;
        }
    }

    //add item to hand
    public void AddItem(Item addedItem)
    {
        itemInHand = addedItem;
    }

    //remove item from hand
    public void RemoveItem()
    {
        itemInHand = null;
    }

    private void TriggerEvent(InputAction.CallbackContext context)
    {
        if(raycast==null) { return; }
        if(raycast.TryGetCurrentUIRaycastResult(out RaycastResult RayCastResult))
        {
            InventorySlot slot = RayCastResult.gameObject.GetComponent<InventorySlot>();
            if(slot!=null)
            {
                slot.interactWithSlot(this);
            }
        }
    }

    private void GripStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Started");
    }

    private void GripCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Cancelled");
    }

    private void GripPerformed(InputAction.CallbackContext context)
    {
        /*//add item to inventory if:
        ///hand has item in it and is gripping it as they enter
        
        //grab backpack if:
        ///hand is empty
        /// grip action is called while in trigger area
        if(directInteractor==null){return; }*/

        if(isFlatScreenMode)
        {
            //if(grabRaycast.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            //{
                /*Item item = RayCastResult.gameObject.GetComponent<Item>();
                if(item!=null)
                {
                    if(this.itemInHand==null)
                    {
                        Debug.Log("Can Pickup item");
                    }
                    else
                    {
                        Debug.Log("Cannot pick up item");
                    }
                }*/
            //}
        }
        else
        {
            //condition to pick up item
            //condition to grab backpack
        }
    }
}
