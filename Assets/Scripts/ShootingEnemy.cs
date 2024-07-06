using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : Enemy
{
    public float shootingInterval = 4f;
    private float shootingTimer;
    public float shootingDistance = 3f;
    private Player player;
    private NavMeshAgent agent;
    public float chasingDistance = 10f;
    public float chasingInterval = 2f;
    private float chasingTimer;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        shootingTimer = Random.Range(0, shootingInterval);
        chasingTimer = chasingInterval;
    }

    void Update()
    {
        HandleShooting();
        HandleChasing();
    }

    private void HandleShooting()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= shootingDistance)
        {
            shootingTimer = shootingInterval;
            GameObject bulletObject = ObjectPoolingManeger.Instance.Bullets(false);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = (player.transform.position - transform.position).normalized;
        }
    }

    private void HandleChasing()
    {
        chasingTimer -= Time.deltaTime;
        if (chasingTimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= chasingDistance)
        {
            chasingTimer = chasingInterval;
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    protected override void OnKill()
    {
        base.OnKill();
        agent.enabled = false;
        this.enabled = false;
        transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}