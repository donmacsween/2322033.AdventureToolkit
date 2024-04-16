// Author : Don MacSween.
// Purpose: Controller for adding, removing and listing inventroy items.
using System.Collections.Generic;
using UnityEngine;

namespace ADVTK
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }

        // Set to public read to allow the InventoryDisplay script limited access.
        [SerializeField] public List<ItemSO> Inventory { get; private set; } = new List<ItemSO>();

        private void Awake()
        {
            EnforceSingleton();
        }

        /// <summary>
        /// Enforces that this object uses the singleton design pattern.
        /// </summary>
        private void EnforceSingleton()
        {
            // If there is already an instance of this destroy this object.
            if (Instance != null && Instance != this)
            { Destroy(this); }
            // Otherwise set the instance to this object
            else { Instance = this; }
        }

        /// <summary>
        /// Adds the passed item to the Inventory List
        /// </summary>
        /// <param name="item">An item scriptable object</param>
        public void AddItemToInventory(ItemSO item)
        {
            Inventory.Add(item);
            FlagManager.Instance.SetFlag("hasItem"+item.itemName, true);
            PopUpMessage.Instance.ShowMessage(item.itemName + " added to inventory.");
        }
        /// <summary>
        /// Removes the passed item from the Inventory List
        /// </summary>
        /// <param name="item">An item scriptable object</param>
        public void RemoveItemFromInventory(ItemSO item)
        {
            PopUpMessage.Instance.ShowMessage(item.itemName + " removed from inventory.");
            Inventory.Remove(item);
            FlagManager.Instance.RemoveFlag("hasItem" + item.itemName);
        }
        public List<ItemSO> ListInventoryItems()
        {
            SortItemsAlphabetically(Inventory);
            return Inventory;
        }
        /// <summary>
        /// Bubble sorts an array of items by the itemName
        /// </summary>
        /// <param name="items">A list of item scriptable objects</param>
        private void SortItemsAlphabetically(List<ItemSO> items)
        {
            ItemSO tempItemHolder = null;
            int    numberOfItems  = items.Count;
            // No point in sorting if we only have 1 item
            if (numberOfItems > 1)
            {
                for (int j = 0; j < numberOfItems - 1; j++)
                {
                    for (int i = j + 1; i < numberOfItems; i++)
                    {
                        // check if a swap is needed
                        if (items[j].itemName.CompareTo(items[i].itemName) > 0)
                        {
                            // Store it so we can do the swap
                            tempItemHolder = items[j];
                            // swap the position of the two items
                            items[j] = items[i];
                            items[i] = tempItemHolder;
                        }
                    }
                }
                Inventory = items;
            }
        }
    }
}
// Notable Resources:
// Microsoft C# reference: CompareTo(String) https://learn.microsoft.com/en-us/dotnet/api/system.string.compareto?view=net-8.0#system-string-compareto(system-string
