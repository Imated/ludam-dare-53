using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public float cost;
}
