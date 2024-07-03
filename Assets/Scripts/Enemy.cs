using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour
{
    private FirstPersonController player;
    public float EnemySpeed = 5;
    public float currSpeed;
    public float stopDist = 4;
    void Start()
    {
        currSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
