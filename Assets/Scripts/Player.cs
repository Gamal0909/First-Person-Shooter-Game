using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Player_cam;
    public GameObject BulletPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject BulletObject=Instantiate(BulletPrefab);
            BulletObject.transform.position = Player_cam.transform.position+transform.forward;
            BulletObject.transform.forward = Player_cam.transform.forward;
        }
    }
}
