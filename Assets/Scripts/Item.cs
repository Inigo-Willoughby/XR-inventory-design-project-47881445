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
        var interactor = args.interactorObject;
        PlayerHand hand = interactor.transform.GetComponentInParent<PlayerHand>();
        if(hand!=null)
        {
            hand.AddItem(this);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        PlayerHand hand = interactor.transform.GetComponentInParent<PlayerHand>();
        if(hand!=null)
        {
            hand.DropItem();
        }
    }

    private void updateStatus()
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        if(rb!=null)
        {
            rb.useGravity = !isHeld;
            rb.isKinematic = isHeld;
        } 
    }
}
