using UnityEngine;

public class CameraNavigation : MonoBehaviour
{
    [SerializeField] private Vector2 _boundsX;
    [SerializeField] private Vector2 _boundsZ;
    [SerializeField] private float _moveSpeed;

    private float _rotY = 0f;
    private float _rotX = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Двигает камеру
        UpdatePosition();
        // Поворячивает камеру
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _rotY += mouseX;
        _rotX -= mouseY;

        transform.eulerAngles = new Vector3(_rotX, _rotY, 0f);
    }

    private void UpdatePosition()
    {
        float dX = Input.GetAxis("Horizontal");
        float dZ = Input.GetAxis("Vertical");
        var delta = new Vector3(dX, 0f, dZ) * Time.deltaTime * _moveSpeed;

        transform.Translate(delta);

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _boundsX.x, _boundsX.y);
        pos.z = Mathf.Clamp(pos.z, _boundsZ.x, _boundsZ.y);
        transform.position = pos;
    }
}
