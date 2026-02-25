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

        // Проверяем: есть ли скрипт, совпадает ли тип и свободен ли слот
        if (item != null && item.itemType == requiredType && transform.childCount == 0)
        {
            item.isSnapped = true;
            item.transform.SetParent(transform);
            item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            // Включаем 3D модель на персонаже
            ToggleVisual(true, item.armorID);

            // УДАЛЯЕМ ИЛИ КОММЕНТИРУЕМ ЭТУ СТРОКУ:
            // item.GetComponent<Image>().enabled = false; 

            // Теперь DragItem.OnEndDrag сам решит, сделать иконку полупрозрачной или нет.
        }
    }
}

    [Header("Steve Visuals")]
public GameObject[] steveVisuals;

[Header("Alex Visuals")]
public GameObject[] alexVisuals;

public GameObject steveObject;

public bool isVisible = true;

public void ToggleVisual(bool show, int id)
{
    foreach (GameObject v in steveVisuals) if (v != null) v.SetActive(false);
    foreach (GameObject v in alexVisuals) if (v != null) v.SetActive(false);

    if (show && isVisible)
    {
        if (steveObject != null && steveObject.activeInHierarchy) 
        {
            if (id >= 0 && id < steveVisuals.Length) steveVisuals[id].SetActive(true);
        }
        else 
        {
            if (id >= 0 && id < alexVisuals.Length) alexVisuals[id].SetActive(true);
        }
    }
}

public void OnToggleVisibility(bool check)
{
    isVisible = check;
    
    DragItem item = GetComponentInChildren<DragItem>();
    if (item != null)
    {
        ToggleVisual(true, item.armorID);
    }
}
}
