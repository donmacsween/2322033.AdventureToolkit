
using ADVTK;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    [SerializeField] ItemSO demoItem;

    // Added on start to ensure that the Inventory Manager instance is available
    private void Start()
    {
        InventoryManager.Instance.AddItemToInventory(demoItem);
    }
}
