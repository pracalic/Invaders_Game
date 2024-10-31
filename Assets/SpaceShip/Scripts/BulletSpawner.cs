using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;  
    public AudioSource bulletShotSound;      

    void Start()
    {
        if (bulletShotSound == null)
        {
            bulletShotSound = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        if (bulletShotSound != null)
        {
            bulletShotSound.Play();
        }
    }
}
