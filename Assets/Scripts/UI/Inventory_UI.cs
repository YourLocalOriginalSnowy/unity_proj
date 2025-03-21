using UnityEngine;
using System.Collections.Generic;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory() //Toggle the inventory UI
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                //if(player.inventory.slots[i].count > 0)
                if(player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    //public void Remove(int slotID)
    //{
        //Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(
            //player.inventory.slots[slotID].type);

        //if (itemToDrop != null)
        //{
            //player.DropItem(itemToDrop);
            //player.inventory.Remove(slotID);
            //Refresh();
        //}

    //}
    public void Remove(int slotID)
    {
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(
         player.inventory.slots[slotID].type);

        if (itemToDrop != null)
        {
            bool dropSuccessful = player.DropItem(itemToDrop);
            if (dropSuccessful)
            {
                player.inventory.Remove(slotID);
                Refresh();
            }
            // Don't remove from inventory or refresh if drop failed
        }
    }
}
