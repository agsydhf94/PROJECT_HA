using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletShootBehavior : IWeaponBehavior

{
    private float lastShootTime = 0f;
    public float fireRate = 0.1f;

    public void Attack(WeaponBase weapon)
    {
        if (Time.time > lastShootTime + fireRate)
        {

            // ÃÑ¾Ë »ý¼ºÇÏ±â
            var newBullet = Instantiate(bulletPrefab);
            var cameraTransform = Camera.main.transform;
            newBullet.transform.SetPositionAndRotation(cameraTransform.position, cameraTransform.rotation);
            newBullet.gameObject.SetActive(true);


            // ½´ÆÃ °¡´É
            lastShootTime = Time.time;
            gunController.PlaySE(fire_Sound);
            crosshair.FireAnimation();
            currentBulletCount--;

            // Muzzle ÀÌÆåÆ® ¸¸µé±â
            var newMuzzle = Instantiate(muzzlePrefab);
            newMuzzle.transform.SetPositionAndRotation(firePosition.position, firePosition.rotation * Quaternion.Euler(90, 0, 90));
            newMuzzle.gameObject.SetActive(true);
            Destroy(newMuzzle, 0.12f);

            

            // ÅºÇÇ »ý¼º

            

        }
    }
}
