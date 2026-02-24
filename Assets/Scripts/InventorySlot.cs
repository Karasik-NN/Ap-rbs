using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string requiredType;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

            if (item != null)
            {
                DragItem alreadyPlacedItem = GetComponentInChildren<DragItem>();

                if (alreadyPlacedItem != null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(requiredType) && item.itemType != requiredType)
                {
                    return;
                }

                item.isSnapped = true;
                item.transform.SetParent(transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                AudioManager.instance.PlayEquip();
                ArmorSlot armorSlot = GetComponent<ArmorSlot>();
                if (armorSlot != null)
                {
                    armorSlot.ToggleVisual(true, item.armorID);
                    item.GetComponent<Image>().enabled = false;
                }
            }
        }
    }
}