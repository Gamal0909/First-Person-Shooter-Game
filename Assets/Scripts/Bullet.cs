using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float bulletLife = 2f;
    public int damage = 5;
    private float lifeTimer;
    private bool shotByPlayer;

    public bool ShotByPlayer
    {
        get { return shotByPlayer; }
        set { shotByPlayer = value; }
    }

    void OnEnable()
    {
        lifeTimer = 0f;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= bulletLife)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && ShotByPlayer)
            {
                enemy.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}