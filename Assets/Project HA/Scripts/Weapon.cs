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
        public GunController gunController;

        public string gunName;
        public float range = 100f;
        public float fireRate = 0.1f;
        public float accuracy;
        public float reloadTime;

        public int damagePoint;

        [Header("Magazine Status")]
        public int reloadBulletCount; // źâ �뷮
        public int currentBulletCount; // ���� źâ�� �� �� �����ִ���
        public int maxBulletCount; // �κ��丮�� ���� ������ �ִ� źȯ��
        public int carryBulletCount; // ���� �������� źȯ ����

        public float retroActionForce; // �ѱ� �ݵ�����
        public float retroActionFineSightForce; // ������ �� �ݵ�����

        public AudioClip fire_Sound;







        private float lastShootTime = 0f;

        private void Awake()
        {
            animator = GameObject.Find("HA.Character.Player").GetComponent<Animator>();
            gunController = GameObject.Find("WeaponHolder").GetComponent<GunController>();
        }


        public void Shoot()
        {
            if (Time.time > lastShootTime + fireRate)
            {
                // ���� ����
                lastShootTime = Time.time;
                gunController.PlaySE(fire_Sound);

                // Muzzle ����Ʈ �����
                var newMuzzle = Instantiate(muzzlePrefab);
                newMuzzle.transform.SetPositionAndRotation(firePosition.position, firePosition.rotation * Quaternion.Euler(90,0,90));
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

            }
        }
    }
}
