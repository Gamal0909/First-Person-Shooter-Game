using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Player_cam;

    public int InitialAmmo = 10;
    private int currAmmo;
    public int Ammo
    {
        get { return currAmmo; }
    }

    public int InitialHealth = 100;
    private int currHealth;
    public int Health
    {
        get { return currHealth; }
    }

    public float Knockback = 5f;
    private bool isHurt = false;
    public float hurtTime = 0.5f;

    void Start()
    {
        currAmmo = InitialAmmo;
        currHealth = InitialHealth;
    }

    void Update()
    {
        FireOn();
    }

    void FireOn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currAmmo > 0)
            {
                currAmmo--;
                GameObject bulletObject = ObjectPoolingManeger.Instance.Bullets(true);
                bulletObject.transform.position = Player_cam.transform.position + Player_cam.transform.forward;
                bulletObject.transform.forward = Player_cam.transform.forward;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        // Ammo collide
        if (currAmmo < InitialAmmo && other.TryGetComponent(out AmmoCreate ammoCreate))
        {
            currAmmo += ammoCreate.ammo;
            Destroy(ammoCreate.gameObject);
        }
        // Health collide
        else if (currHealth < InitialHealth && other.TryGetComponent(out GetHealth getHealth))
        {
            currHealth += getHealth.healthPlus;
            Destroy(getHealth.gameObject);
        }
        // Touching Enemy
        else if (!isHurt)
        {
            GameObject hazard = null;

            if (other.TryGetComponent(out Enemy enemy))
            {
                hazard = enemy.gameObject;
                currHealth -= enemy.damage;
            }
            else if (other.TryGetComponent(out Bullet bullet) && !bullet.ShotByPlayer)
            {
                hazard = bullet.gameObject;
                currHealth -= bullet.damage;
                bullet.gameObject.SetActive(false);
            }

            if (hazard != null)
            {
                isHurt = true;
                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackVec = (hurtDirection + Vector3.up).normalized;
                
                GetComponent<ForceReceiver>().AddForce(knockbackVec, Knockback);
                StartCoroutine(HurtRoutine());
            }
        }
    }

    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtTime);
        isHurt = false;
    }
}
