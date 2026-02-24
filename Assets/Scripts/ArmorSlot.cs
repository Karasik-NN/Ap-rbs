using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorSlot : MonoBehaviour, IDropHandler
{
    public string slotType;

    public void OnDrop(PointerEventData eventData)
    {
        DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

        if (item != null)
        {
            if (item.itemType == slotType)
            {
                item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}