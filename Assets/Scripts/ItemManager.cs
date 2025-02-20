using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectableItems; // Array of Collectable items

    private Dictionary<CollectableType, Collectable> collectableItemsDict = // Fix the type name here
        new Dictionary<CollectableType, Collectable>();
    
    private void Awake()
    {
        // Loop through each collectable item and add it to the dictionary
        foreach(Collectable item in collectableItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if(!collectableItemsDict.ContainsKey(item.type)) // Check if the dictionary already contains the item type
        {
            collectableItemsDict.Add(item.type, item); // If not, add the item type and the item itself to the dictionary
        }
    }

    // Method to retrieve an item by its type
    public Collectable GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }
        else
        {
            return null;
        }
    }
}
