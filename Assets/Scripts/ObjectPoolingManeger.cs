using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManeger : MonoBehaviour
{
    private static ObjectPoolingManeger instance;
    public static ObjectPoolingManeger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPoolingManeger>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ObjectPoolingManager");
                    instance = obj.AddComponent<ObjectPoolingManeger>();
                }
            }
            return instance;
        }
    }

    public GameObject BulletPrefab;
    public int BulletAmount = 30;
    private List<GameObject> bulletsList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optionally, keep the manager alive across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        bulletsList = new List<GameObject>(BulletAmount);
        for (int i = 0; i < BulletAmount; i++)
        {
            GameObject preBullet = Instantiate(BulletPrefab);
            preBullet.transform.SetParent(transform);
            preBullet.SetActive(false);
            bulletsList.Add(preBullet);
        }
    }

    public GameObject Bullets(bool shotByPlayer)
    {
        foreach (GameObject bullet in bulletsList)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return bullet;
            }
        }

        // If no inactive bullet is found, create a new one and add it to the pool
        GameObject preBullet = Instantiate(BulletPrefab);
        preBullet.transform.SetParent(transform);
        preBullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
        preBullet.SetActive(false);
        bulletsList.Add(preBullet);
        return preBullet;
    }
}
