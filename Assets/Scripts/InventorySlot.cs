using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string requiredType = ""; 

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

            if (item != null)
            {
                bool typeMatches = string.IsNullOrEmpty(requiredType) || item.itemType == requiredType;
                
                bool isEmpty = transform.childCount == 0;

                if (typeMatches && isEmpty)
                {
                    item.isSnapped = true;
                    item.transform.SetParent(transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    Debug.Log("Предмет успешно положен");
                }
                else
                {
                    Debug.Log("Нельзя положить: либо тип не тот, либо слот занят");
                }
            }
        }
    }
}