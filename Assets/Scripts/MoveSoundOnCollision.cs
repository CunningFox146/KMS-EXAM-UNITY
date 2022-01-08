using UnityEngine;

public class MoveSoundOnCollision : MonoBehaviour
{
    [SerializeField] private Color _color;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Awake()
    {
        // Эти компоненты должны быть на кубике. Звук должен быть установлен заранее, PlayOnAwake снят
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //Двигаем вперед 
        _rb.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // У цели должен быть тег "Target". Добавить его в инспекторе
        if (collision.gameObject.CompareTag("Target"))
        {
            _audioSource.Play();
        }
    }
}
