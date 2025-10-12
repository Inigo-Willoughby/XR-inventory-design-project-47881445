using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject prefab;
    //item name
    //other items that this can be crafted with
    //(Other, Result)
    //(Other, Result)

    public void pickUp(PlayerHand hand)
    {
        if(hand.IsFlatScreenMode)
        {
            this.transform.position = hand.ItemPoint.transform.position;
            //set parent
            //disable gravity
            //hand.addItem(This);
        }
    }   
}
