using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ADVTK/InventoryItem")]
    public class ItemSO : ScriptableObject
    {
        public string     itemName          = string.Empty;
        public string     itemDescription   = string.Empty;
        public Sprite     itemThumbnail     = null;
        public GameObject itemPrefab        = null;
    }
}
