using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Item Settings")]
    public string itemType;
    public int armorID;
    
    [HideInInspector] public Transform startParent;
    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public bool isSnapped = false;
    
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startParent = transform.parent;
        startPosition = transform.position;
        isSnapped = false;

        ArmorSlot oldSlot = startParent.GetComponent<ArmorSlot>();
        if (oldSlot != null) oldSlot.ToggleVisual(false, 0);

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.root.localScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!isSnapped)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
        
        GetComponent<Image>().enabled = true;
    }
}