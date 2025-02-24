using UnityEngine;
using System.Collections.Generic; // Required for using List<Type>

[System.Serializable]
public class Inventory
{
   [System.Serializable]
   public class Slot
   {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 10;
        }

        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if(count == 0)
                {
                    type = CollectableType.NONE;
                    icon = null;
                }
                 else
                {
                    // Re-fetch the persistent sprite to ensure the reference is valid.
                    Collectable persistentItem = GameManager.instance.itemManager.GetItemByType(type);
                    if(persistentItem != null)
                    {
                        icon = persistentItem.icon;
                    }
                }
            }
        }
   }

   public List<Slot> slots = new List<Slot>();

   public Inventory(int numSlots)
   {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
   }

   public void Add(Collectable item)
   {
        // Retrieve the persistent collectible reference (which holds the proper sprite)
        Collectable persistentItem = GameManager.instance.itemManager.GetItemByType(item.type);
        
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
   }

   public void Remove(int index)
   {
        slots[index].RemoveItem();
   }
}
