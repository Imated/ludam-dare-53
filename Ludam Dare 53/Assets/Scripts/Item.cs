using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Sprite roomItem;
    public float cost;
}
