using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject prefab;
    //other items that this can be crafted with
    //(Other, Result)
    //(Other, Result)
    private bool isHeld;

    public void pickUp(PlayerHand hand)
    {
        if(hand.IsFlatScreenMode)
        {
            this.transform.position = hand.ItemPoint.transform.position;
            this.transform.SetParent(hand.ItemPoint.transform);
            isHeld = true;
            updateStatus();
            hand.AddItem(this);
        }
    }   

    public void Drop()
    {
        this.transform.SetParent(null);
        isHeld = false;
        updateStatus();
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
