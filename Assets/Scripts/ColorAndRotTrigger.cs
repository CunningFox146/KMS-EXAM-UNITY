using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAndRotTrigger : MonoBehaviour
{
    [SerializeField] private Color _color;
    private Dictionary<GameObject, Color> _colorMap;

    private void Awake()
    {
        _colorMap = new Dictionary<GameObject, Color>();
    }

    public void OnTriggerEnter(Collider other)
    {
        // При коллизии начинаем корутину, передавая то с чем столкнулись
        StartCoroutine(RotateObjectCoroutine(other.transform));

        //Пытаемся получить компонент отвечающий за материал
        if (other.TryGetComponent(out Renderer renderer))
        {
            //Созраняем исходный цвет
            _colorMap[other.gameObject] = renderer.material.color;
            //Ставим другой
            renderer.material.color = _color;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Renderer renderer) && _colorMap.ContainsKey(other.gameObject))
        {
            renderer.material.color = _colorMap[other.gameObject];
            _colorMap.Remove(other.gameObject);
        }
    }

    private IEnumerator RotateObjectCoroutine(Transform target)
    {
        while (true)
        {
            //target.Rotate(Vector3.up * Time.deltaTime * 180f);
            // Тут для задания про вращение через кватернеоны. Кватернионы перемножаются наоборот (на сколько поворачиваем) * (текущий поворот).
            target.rotation = Quaternion.AngleAxis(Time.deltaTime * 180f, Vector3.up) * target.rotation;
            yield return null; // Ждем следующий кадр
        }
    }
}