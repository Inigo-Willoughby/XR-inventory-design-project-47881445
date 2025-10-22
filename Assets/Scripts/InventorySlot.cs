using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class InventorySlot : MonoBehaviour
{
    public ItemData itemInSlot;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI slotText;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnSlotClicked);

        slotText = this.GetComponentInChildren<TextMeshProUGUI>();
        if(slotText!=null)
        {
            slotText.text = "";
        }
    }

    public void interactWithSlot(PlayerHand hand)
    {
        if(checkIfEmpty())
        {
            tryAddItem(hand);
        }
        else
        {
            tryRemoveItem(hand);
        }
    }

    private void OnSlotClicked()
    {
        Debug.Log("Clicked");
    }

    //try and add item to slot
    private void tryAddItem(PlayerHand hand)
    {
        if(hand == null ||hand.itemInHand == null) { return; }

        ItemData newItem = hand.itemInHand.data;

        updateSlot(newItem);

        hand.RemoveItem();
    }

    //try and remove item from slot
    private void tryRemoveItem(PlayerHand hand)
    {
        if(hand == null || this.itemInSlot==null) { return; }
        //get interactor from hand
        
        GameObject ItemObject = Instantiate(this.itemInSlot.prefab, transform.position, transform.rotation);
        updateSlot(null);
        StartCoroutine(moveItemToHand(hand.Raycast, ItemObject.gameObject.GetComponent<XRGrabInteractable>()));
    }

    private void updateSlot(ItemData newItem)
    {
        this.itemInSlot = newItem;
        if(newItem!=null)
        {
            slotText.text = itemInSlot.itemName;
        }
        else
        {
            slotText.text = "";
        }
    }

    private bool checkIfEmpty()
    {
        return itemInSlot==null;
    }

    IEnumerator moveItemToHand(XRBaseInteractor hand, XRBaseInteractable interactable)
    {
        yield return null;

        XRInteractionManager manager = FindFirstObjectByType<XRInteractionManager>();
        manager.SelectEnter(hand as IXRSelectInteractor, interactable as IXRSelectInteractable);
    }
}
