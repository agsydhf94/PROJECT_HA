using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Weapon : MonoBehaviour
    {

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(firePosition.position, firePosition.position + firePosition.forward * range);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * range);
        }

        public GameObject bulletPrefab;
        public GameObject muzzlePrefab;
        public GameObject bulletCartridgePrefab;
        public Transform firePosition;
        public Transform bulletCartRidgePosition;
        public Animator animator;
        


        public float fireRate = 0.1f;
        public float range = 100f;

        private float lastShootTime = 0f;

        private void Awake()
        {
            animator = GameObject.Find("HA.Character.Player").GetComponent<Animator>();            
        }

        private void Update()
        {
            
        }

        public void Shoot()
        {
            if (Time.time > lastShootTime + fireRate)
            {
                // ½´ÆÃ °¡´É
                lastShootTime = Time.time;

                // Muzzle ÀÌÆåÆ® ¸¸µé±â
                var newMuzzle = Instantiate(muzzlePrefab);
                newMuzzle.transform.SetPositionAndRotation(firePosition.position, firePosition.rotation * Quaternion.Euler(90,0,90));
                newMuzzle.gameObject.SetActive(true);
                Destroy(newMuzzle, 0.12f);

                // ÃÑ¾Ë »ý¼ºÇÏ±â
                var newBullet = Instantiate(bulletPrefab);
                var cameraTransform = Camera.main.transform;
                newBullet.transform.SetPositionAndRotation(cameraTransform.position, cameraTransform.rotation);
                newBullet.gameObject.SetActive(true);

                // ÅºÇÇ »ý¼º

                var newbulletCartridge = Instantiate(bulletCartridgePrefab);
                newbulletCartridge.transform.SetPositionAndRotation(bulletCartRidgePosition.position, bulletCartRidgePosition.rotation);
                newbulletCartridge.GetComponent<Rigidbody>().AddForce(Vector3.left);

            }
        }
    }
}
