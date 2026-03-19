using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color defaultColor;
    public TMP_Text text;
    public Color newColor;

    void Awake()
    {
        defaultColor = text.color;
    }

    void OnEnable()
    {
        text.color = defaultColor;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = newColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = defaultColor;
    }
}
