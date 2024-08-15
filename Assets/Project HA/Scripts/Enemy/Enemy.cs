using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public float enemyHp = 100.0f;
    public bool isDead = false;

    public GameObject projectile;
    public Transform projectilePoint;
    public float bulletPower = 300f;

    public RagdollController ragdollController;

    private void Awake()
    {
        ragdollController = GetComponent<RagdollController>();
    }

    private void Update()
    {
        if (enemyHp > 0)
        {
            isDead = false;
        }
        else
        {
            isDead = true;
            // ragdollController.ActiveRagdoll();
            gameObject.SetActive(!isDead);
        }
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletPower, ForceMode.Impulse);
    }

       
    public void Damage(float damagePoint)
    {
        if(!isDead)
        {
            enemyHp -= damagePoint;
        }
    }

    
}
