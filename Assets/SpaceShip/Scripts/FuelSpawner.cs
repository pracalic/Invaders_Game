using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 5f;
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        if (edgeCollider == null) return;

        Vector2[] points = edgeCollider.points;
        int randomIndex = Random.Range(0, points.Length);
        Vector2 point1 = transform.TransformPoint(points[randomIndex]);
        Vector2 point2 = transform.TransformPoint(points[(randomIndex + 1) % points.Length]);
        Vector2 randomPointOnEdge = Vector2.Lerp(point1, point2, Random.Range(0f, 1f));

        Instantiate(prefabToSpawn, randomPointOnEdge, Quaternion.identity);
    }
}
