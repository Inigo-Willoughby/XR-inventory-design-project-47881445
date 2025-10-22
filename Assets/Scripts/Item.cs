using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Item : MonoBehaviour
{
    public GameObject prefab;
    private bool isHeld;
    private XRGrabInteractable grabInteractable;
    public ItemData data;

    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();
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
        }
    }
}
