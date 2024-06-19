using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public float lifeTime = 10;

    public GameObject metalImpactPrefab;
    public GameObject woodImpactPrefab;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string physicMaterialName = collision.collider.material.name;
        string[] splitNames = physicMaterialName.Split(" ");
        string originalName = splitNames[0];

        if (originalName.Equals("PhysicMaterial_Metal"))
        {
            var newImpact = Instantiate(metalImpactPrefab);
            newImpact.transform.SetPositionAndRotation(collision.contacts[0].point, Quaternion.Euler(collision.contacts[0].normal));
        }

        if (originalName.Equals("PhysicMaterial_Wood"))
        {
            var newImpact = Instantiate(woodImpactPrefab);
            newImpact.transform.SetPositionAndRotation(collision.contacts[0].point, Quaternion.Euler(-collision.contacts[0].normal));
        }

        Destroy(gameObject);


        

    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.Damage();
        }
    }


}
