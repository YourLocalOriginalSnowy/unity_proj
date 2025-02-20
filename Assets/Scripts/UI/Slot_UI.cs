using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
   public Image itemIcon;
   public TextMeshProUGUI quantityText;

   public void SetItem(Inventory.Slot slot)
   {
        if(slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1); //shows the icon of the item in the slot
            quantityText.text = slot.count.ToString();
        }
   }

   public void SetEmpty()
   {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0); //hides the icon when there is no item in slot
        quantityText.text = "";
   }
}
