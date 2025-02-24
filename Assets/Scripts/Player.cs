using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Inventory_UI inventoryUI;
    public LayerMask boundaryLayer; // Add this to check for boundaries

    private void Awake()
    {
        inventory = new Inventory(10);
    }

    public bool DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle *1.25f;

        //Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, 
            //Quaternion.identity;

        //droppedItem.rb2d.AddForce(spawnOffset * 0.20f, ForceMode2D.Impulse);

        Vector2 finalPosition = spawnLocation + spawnOffset;

        // Check if the spawn position is valid (not inside boundaries)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(finalPosition, 0.1f, boundaryLayer);
        if (colliders.Length > 0)
        {
            // Position is invalid, return false to indicate drop failed
            return false;
        }

        // Position is valid, spawn the item
        Collectable droppedItem = Instantiate(item, finalPosition, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * 0.20f, ForceMode2D.Impulse);
        return true;
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

