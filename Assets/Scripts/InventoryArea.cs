using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

            if (item != null)
            {
                item.isSnapped = true; 

                item.transform.SetParent(transform);

                item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); 

                Debug.Log("Предмет снят и возвращен в панель инвентаря!");
            }
        }
    }
}