
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ADVTK
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] TMP_Text itemName;
        [SerializeField] TMP_Text itemDescription;
        [SerializeField] Image    itemIcon;

        /// <summary>
        /// Applies the supplied item details to a newly instantiated prefab template.
        /// </summary>
        /// <param name="item">An inventory item</param>
        public void ApplyItemToPrefab(ItemSO item)
        {
            itemName.text        = item.itemName;
            itemDescription.text = item.itemDescription;
            itemIcon.sprite      = item.itemThumbnail;
        }
    }
}
