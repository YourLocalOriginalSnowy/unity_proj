using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Inventory_UI inventoryUI;

    private void Awake()
    {
        inventory = new Inventory(10);
    }

    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle *1.25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, 
            Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * 0.20f, ForceMode2D.Impulse);
    }

    public void CollectItem(Collectable item)
    {
        inventory.Add(item); // Add the item to the inventory
        if (inventoryUI != null) // Ensure inventoryUI is not null
        {
            inventoryUI.Refresh(); // Refresh the UI to reflect the new item
        }
    }
}

