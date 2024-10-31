using UnityEngine;

public class FuelTank : MonoBehaviour
{
    [SerializeField] private ParticleSystem starParticles;
    [SerializeField] private float speed;

    void Start()
    {
        GameObject starsObj = GameObject.FindGameObjectWithTag("Stars");
        if (starsObj != null)
        {
            starParticles = starsObj.GetComponent<ParticleSystem>();
        }

    }

    void Update()
    {
        if (starParticles != null)
        {
            speed = starParticles.velocityOverLifetime.speedModifier.constant; 
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyMe") || other.CompareTag("SpaceShip"))
            Destroy(gameObject);
    }
}
