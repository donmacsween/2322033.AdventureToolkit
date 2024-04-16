// Author : Don MacSween.
// Purpose: this script populates a display canvas with inventory objects
using System.Collections.Generic;
using UnityEngine;

namespace ADVTK
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private Transform      inventoryItemContainer;
        [SerializeField] private InventoryItem  inventoryItemPrefab;
                         private List<ItemSO>   items;
        
        /// <summary>
        /// Runs when the panel is displayed in game
        /// </summary>
        private void OnEnable()
        {
            CreateInventoryList();
        }
        /// <summary>
        ///  and cleared when it is hidden
        /// </summary>
        private void OnDisable()
        {
            ClearInventoryList();
        }
        /// <summary>
        /// Instanciates inventory item prefabs and populates them with data
        /// </summary>
        private void CreateInventoryList ()
        {
            items = InventoryManager.Instance.ListInventoryItems();
            if (items != null)
            {
                foreach (ItemSO item in items)
                {
                    InventoryItem itemTemplate = Instantiate(inventoryItemPrefab, inventoryItemContainer);
                    itemTemplate.ApplyItemToPrefab(item);
                }
            }
        }
        /// <summary>
        /// Removes all child canvas elements ready for next access
        /// </summary>
        private void ClearInventoryList()
        {
            
            for (var i = inventoryItemContainer.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(inventoryItemContainer.GetChild(i).gameObject);
            }
        }
    }
}
