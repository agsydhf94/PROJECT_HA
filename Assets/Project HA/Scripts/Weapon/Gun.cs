using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Gun : WeaponBase
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float fireForce = 20f;

        private float lastShootTime = 0f;
        public float fireRate = 0.1f;

        public override void Shoot()
        {
            if (Time.time > lastShootTime + fireRate)
            {
                // ���� ����
                lastShootTime = Time.time;
                gunController.PlaySE(fire_Sound);
                crosshair.FireAnimation();
                currentBulletCount--;

                // Muzzle ����Ʈ �����
                var newMuzzle = Instantiate(muzzlePrefab);
                newMuzzle.transform.SetPositionAndRotation(firePosition.position, firePosition.rotation * Quaternion.Euler(90, 0, 90));
                newMuzzle.gameObject.SetActive(true);
                Destroy(newMuzzle, 0.12f);

                // �Ѿ� �����ϱ�
                var newBullet = Instantiate(bulletPrefab);
                var cameraTransform = Camera.main.transform;
                newBullet.transform.SetPositionAndRotation(cameraTransform.position, cameraTransform.rotation);
                newBullet.gameObject.SetActive(true);

                // ź�� ����

                var newbulletCartridge = Instantiate(bulletCartridgePrefab);
                newbulletCartridge.transform.SetPositionAndRotation(bulletCartRidgePosition.position, bulletCartRidgePosition.rotation);
                newbulletCartridge.GetComponent<Rigidbody>().AddForce(Vector3.left);

                Vector3 velocity = recoilShakePattern[currentRecoilIndex];
                currentRecoilIndex++;
                if (currentRecoilIndex >= recoilShakePattern.Count)
                {
                    currentRecoilIndex = currentRecoilIndex = 0;
                }
                CameraSystem.Instance.ShakeCamera(velocity, 0.2f, 1f);

            }
        }
    }
}
