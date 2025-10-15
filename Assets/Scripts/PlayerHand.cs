using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayerHand : MonoBehaviour
{
    public Item itemInHand;
    private NearFarInteractor raycast;

    [SerializeField] private InputActionAsset ActionMap;
    private InputAction triggerButton;
    private InputAction gripButton;
    [SerializeField] private GameObject itemPoint;
    [HideInInspector] public GameObject ItemPoint { get => itemPoint; }
    [SerializeField] private bool isFlatScreenMode = true;
    [HideInInspector] public bool IsFlatScreenMode { get => isFlatScreenMode; }
    private bool isHolding = false;

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

        gripButton = ActionMap.FindAction("Grip"+inGroup.groupName, true);
        if(gripButton!=null)
        {
            gripButton.Enable();
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
        Destroy(itemInHand.transform.gameObject);
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

    private void GripCanceled(InputAction.CallbackContext context)
    {
        if(this.itemInHand!=null)
        {
            if(isHolding)
            {
                Debug.Log("removing item");
                this.itemInHand.Drop();
                this.itemInHand = null;
                isHolding = false;
            }
            else
            {
                Debug.Log("setting holding mode");
                isHolding = true;
            }
        }
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
            RaycastHit hit;
            if(Physics.Raycast(raycast.transform.position, transform.forward, out hit, 10f))
            {
                Item newItem = hit.transform.gameObject.GetComponent<Item>();
                if(newItem!=null)
                {
                    if(this.itemInHand==null)
                    {
                        newItem.pickUp(this);
                    }
                    else
                    {
                        Debug.Log("Item already in hand");
                    }
                }
            }
            //cast a manual raycasthit?
            /*if(raycast==null) { return; }
            if (raycast.interactablesHovered.Count > 0)
            {
                Item newItem = raycast.interactablesHovered[0].transform.gameObject.GetComponent<Item>();
                if(newItem!=null)
                {
                    if(this.itemInHand==null)
                    {
                        newItem.pickUp(this);
                    }
                    else
                    {
                        Debug.Log("Item already in hand");
                    }
                }
            }*/
        }
        else
        {
            //condition to pick up item
            //condition to grab backpack
        }
    }
}
