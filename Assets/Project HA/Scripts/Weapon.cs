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
        public CrossHair crosshair;

        public string gunName;
        public float range = 100f;
        public float fireRate = 0.1f;
        public float accuracy;
        public float reloadTime;
        public bool isReload = false;

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
            animator = GameObject.Find("FreeTestCharacterAsuna").GetComponent<Animator>();
            gunController = GameObject.Find("WeaponHolder").GetComponent<GunController>();
            crosshair = FindObjectOfType<CrossHair>();
        }


        public void Shoot()
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

        public IEnumerator ReloadCoroutine()
        {
            if(carryBulletCount > 0)
            {
                isReload = true;
                animator.SetTrigger("Reload");

                carryBulletCount += currentBulletCount;
                currentBulletCount = 0;

                

                    yield return new WaitForSeconds(reloadTime);

                if(carryBulletCount >= reloadBulletCount) // �� �� ���� ������ ����� ź�� �����ϰ� �ִٸ�
                {
                    currentBulletCount = reloadBulletCount; // ���� ����
                    carryBulletCount -= reloadBulletCount; // ������ ź ����ŭ �����п��� ����
                }
                else // ���� �ϴµ� ����� ź���� ���ٸ� ( ex-> 30�� �����ؾ� �ϴµ� ������ 20�� ���� �� )
                {
                    currentBulletCount = carryBulletCount;
                    carryBulletCount = 0;
                }

                isReload = false;
            }
        }

        public void CancelReload()
        {
            if(isReload == true)
            {
                StopAllCoroutines();
                isReload = false;
            }
        }
    }
}
