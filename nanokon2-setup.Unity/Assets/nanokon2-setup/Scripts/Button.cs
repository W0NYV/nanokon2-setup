using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _bg;
    [SerializeField] private Color _defColor;
    [SerializeField] private Color _pressedColor;

    public float value { get; private set; }

    public void SetPressedState()
    {
        _bg.color = _pressedColor;
        value = 1f;
    }

    public void SetDefaultState()
    {
        _bg.color = _defColor;
        value = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetPressedState();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetDefaultState();
    }

}
