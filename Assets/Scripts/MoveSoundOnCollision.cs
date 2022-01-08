using UnityEngine;

public class MoveSoundOnCollision : MonoBehaviour
{
    [SerializeField] private Color _color;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Awake()
    {
        // ��� ���������� ������ ���� �� ������. ���� ������ ���� ���������� �������, PlayOnAwake ����
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //������� ������ 
        _rb.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // � ���� ������ ���� ��� "Target". �������� ��� � ����������
        if (collision.gameObject.CompareTag("Target"))
        {
            _audioSource.Play();
        }
    }
}
