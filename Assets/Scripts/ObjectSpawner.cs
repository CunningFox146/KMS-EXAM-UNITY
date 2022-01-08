using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnPrefab();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnRb();
        }
    }

    private void SpawnRb()
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.AddComponent<Rigidbody>();
        obj.transform.position = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range(1f, 10f));
    }

    private void SpawnPrefab()
    {
        var pos = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range(1f, 10f));
        Instantiate(_prefab, pos, Quaternion.identity);
    }
}
