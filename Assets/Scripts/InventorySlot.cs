using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [Header("Slot Settings")]
    public string requiredType;

   public void OnDrop(PointerEventData eventData)
{
    if (eventData.pointerDrag == null) return;

    DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

    if (item != null)
    {
        if (transform.childCount > 0) return;

        string trimRequired = requiredType.Trim();

        if (!string.IsNullOrEmpty(trimRequired))
        {
            if (item.itemType != trimRequired)
            {
                Debug.Log($"Нельзя! Слот хочет {trimRequired}, а у предмета {item.itemType}");
                return; 
            }
        }
       
        item.isSnapped = true;
        item.transform.SetParent(transform);
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        ArmorSlot armorSlot = GetComponent<ArmorSlot>();
        Image itemImage = item.GetComponent<Image>();

        if (armorSlot != null)
        {
            if (AudioManager.instance != null) AudioManager.instance.PlayEquip();
            armorSlot.ToggleVisual(true, item.armorID);
            if (itemImage != null) itemImage.enabled = false;
        }
        else
        {
            if (itemImage != null) itemImage.enabled = true;
            if (AudioManager.instance != null) AudioManager.instance.PlayClick();
        }
    }
}
}