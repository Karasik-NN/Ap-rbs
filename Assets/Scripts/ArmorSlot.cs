using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArmorSlot : MonoBehaviour, IDropHandler
{
    public string requiredType;
    
    [Header("Visual Settings")]
    public GameObject[] armorVisuals;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

            if (item != null && item.itemType == requiredType && transform.childCount == 0)
            {
                item.isSnapped = true;
                item.transform.SetParent(transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                ToggleVisual(true, item.armorID);

                item.GetComponent<Image>().enabled = false;
            }
        }
    }

    public void ToggleVisual(bool show, int id)
    {
        foreach (GameObject visual in armorVisuals)
        {
            if (visual != null) visual.SetActive(false);
        }

        if (show && id < armorVisuals.Length && armorVisuals[id] != null)
        {
            armorVisuals[id].SetActive(true);
        }
    }
}