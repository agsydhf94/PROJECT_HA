using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenade : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionRadius = 13.0f;
    public float explosionForce = 400.0f;
    public float throwForce = 500.0f;

    public float explosionDamage;
    public new Rigidbody rigidbody;

    public void Settings(float damage, Vector3 rotation)
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(rotation * throwForce);

        explosionDamage = damage;
    }

    public void Explosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider hit in colliders)
        { 
        }
    }
}
