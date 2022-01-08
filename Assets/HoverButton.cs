using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Renderer _renderer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _renderer.material.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _renderer.material.color = Color.white;
    }
}
