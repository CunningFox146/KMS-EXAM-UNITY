using UnityEngine;
using UnityEngine.EventSystems;

public class ClickColor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _renderer.material.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _renderer.material.color = Color.white;
    }
}
