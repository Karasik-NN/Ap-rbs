using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorSlot : MonoBehaviour, IDropHandler
{
    public string slotType; 

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

            if (item != null && item.itemType == slotType)
            {
                item.isSnapped = true; 
                
                item.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                
                Debug.Log("Предмет зафиксирован в слоте!");
            }
        }
    }
}