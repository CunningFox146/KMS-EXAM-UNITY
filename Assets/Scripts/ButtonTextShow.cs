using UnityEngine;
using UnityEngine.UI;

public class ButtonTextShow : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => _text.SetActive(!_text.activeSelf));
    }
}
