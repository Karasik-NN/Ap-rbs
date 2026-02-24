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

    [Header("Steve Visuals")]
public GameObject[] steveVisuals;

[Header("Alex Visuals")]
public GameObject[] alexVisuals;

public GameObject steveObject;

public void ToggleVisual(bool show, int id)
{
    foreach (GameObject v in steveVisuals) if(v != null) v.SetActive(false);
    foreach (GameObject v in alexVisuals) if(v != null) v.SetActive(false);

    if (show)
    {
        if (steveObject.activeSelf) 
        {
            if (id < steveVisuals.Length) steveVisuals[id].SetActive(true);
        }
        else 
        {
            if (id < alexVisuals.Length) alexVisuals[id].SetActive(true);
        }
    }
}
public void ResetSlot()
{
    
    DragItem item = GetComponentInChildren<DragItem>();

    if (item != null)
    {
        item.transform.SetParent(item.startParent);
        item.transform.position = item.startPosition;
        
        item.isSnapped = false;

        item.GetComponent<UnityEngine.UI.Image>().enabled = true;

        ToggleVisual(false, 0);
    }
}
}