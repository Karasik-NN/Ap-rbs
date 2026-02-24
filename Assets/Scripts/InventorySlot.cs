using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();
            if (item != null)
            {
                item.isSnapped = true;
                item.transform.SetParent(transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        }
    }
}