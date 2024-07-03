using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=8f;
    public float bulletlife = 4f;
    private float lifetimer;
    void Start()
    {
        lifetimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifetimer += Time.deltaTime;
        if (lifetimer >= bulletlife)
        {
            Destroy(gameObject);
        }
    }
}
