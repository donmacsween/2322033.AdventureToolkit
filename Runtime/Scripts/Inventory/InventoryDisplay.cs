
using System.Collections.Generic;
using UnityEngine;

namespace ADVTK
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private Transform      inventoryItemContainer;
        [SerializeField] private InventoryItem  inventoryItemPrefab;
                         private List<ItemSO>   items;
        

        private void OnEnable()
        {
            CreateInventoryList();
        }

        private void OnDisable()
        {
            ClearInventoryList();
        }
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

        private void ClearInventoryList()
        {
            
            for (var i = inventoryItemContainer.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(inventoryItemContainer.GetChild(i).gameObject);
            }
        }
    }
}
