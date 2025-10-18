using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    //crafting info
}
