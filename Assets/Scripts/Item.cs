using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Item : MonoBehaviour
{
    public GameObject prefab;
    private bool isHeld;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public ItemData data;

    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();
        rb = this.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnSelectEnter);
            grabInteractable.selectExited.AddListener(OnSelectExit);
        }
    }

    void OnDisable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
            grabInteractable.selectExited.RemoveListener(OnSelectExit);
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        PlayerHand hand = interactor.transform.GetComponentInParent<PlayerHand>();
        DynamicInventorySlot slot = interactor.transform.GetComponent<DynamicInventorySlot>();
        if(hand!=null)
        {
            hand.AddItem(this);
        }
        else if(slot!=null)
        {
            slot.AddItem(this);
            this.transform.SetParent(slot.transform);
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        PlayerHand hand = interactor.transform.GetComponentInParent<PlayerHand>();
        DynamicInventorySlot slot = interactor.transform.GetComponent<DynamicInventorySlot>();
        if(hand!=null)
        {
            hand.DropItem();
        }
        else if(slot!=null)
        {
            slot.RemoveItem();
            this.transform.SetParent(null);
        }
    }

    public void SetPhysics(bool state)
    {
        if(rb)
        {
            rb.isKinematic = !state;
            rb.useGravity = state;
        }
        if(grabInteractable)
        {
            grabInteractable.enabled = state;
            Debug.Log("Setting interactivity");
        }
    }
}
