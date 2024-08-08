using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Weapon : MonoBehaviour
    {

        private void OnDrawGizmos()
        {
            if (firePosition)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(firePosition.position, firePosition.position + firePosition.forward * range);
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * range);
        }


        public enum WeaponCategory
        {
            Rifle,
            Pistol,
            Bomb
        }



        public string gunName;
        public float range = 100f;
        public float fireRate = 0.1f;
        public float reloadTime;
        public bool isReload = false;

        public List<Vector3> recoilShakePattern = new List<Vector3>();

        public int damagePoint;

        [Header("Magazine Status")]
        public int reloadBulletCount; // źâ �뷮
        public int currentBulletCount; // ���� źâ�� �� �� �����ִ���
        public int maxBulletCount; // �κ��丮�� ���� ������ �ִ� źȯ��
        public int carryBulletCount; // ���� �������� źȯ ����

        public float retroActionForce; // �ѱ� �ݵ�����
        public float retroActionFineSightForce; // ������ �� �ݵ�����


        public GameObject bulletPrefab;
        public Transform firePosition;
        public GameObject bulletCasingPrefab;
        public Transform bulletCasingPosition;
        public GameObject muzzlePrefab;
        public AudioClip fire_Sound;
        private AudioSource audioSource;
        public CrossHair crosshair;






        private int currentRecoilIndex = 0;
        private float lastShootTime = 0f;

        private void Awake()
        {
            crosshair = FindObjectOfType<CrossHair>();
            audioSource = GetComponent<AudioSource>();
        }


        public void Shoot()
        {
            if (Time.time > lastShootTime + fireRate)
            {
                // ���� ����
                lastShootTime = Time.time;
                PlaySE(fire_Sound);
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

                Quaternion randomQua = new Quaternion(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f), 1);
                GameObject bulletCasing = Instantiate(bulletCasingPrefab);
                bulletCasing.transform.localRotation = randomQua;
                bulletCasing.GetComponent<Rigidbody>().AddRelativeForce(
                    new Vector3(Random.Range(50.0f, 100.0f), Random.Range(50.0f, 100.0f), Random.Range(-40.0f, 40.0f)));
                Destroy(bulletCasing, 1.0f);

                // �ѱ� �ݵ� ����
                Vector3 velocity = recoilShakePattern[currentRecoilIndex];
                currentRecoilIndex++;
                if (currentRecoilIndex >= recoilShakePattern.Count)
                {
                    currentRecoilIndex = currentRecoilIndex = 0;
                }
                CameraSystem.Instance.ShakeCamera(velocity, 0.2f, 1f);

            }
        }

        public void Reload()
        {
            if (carryBulletCount > 0)
            {
                carryBulletCount += currentBulletCount;
                currentBulletCount = 0;

                if (carryBulletCount >= reloadBulletCount) // �� �� ���� ������ ����� ź�� �����ϰ� �ִٸ�
                {
                    currentBulletCount = reloadBulletCount; // ���� ����
                    carryBulletCount -= reloadBulletCount; // ������ ź ����ŭ �����п��� ����
                }
                else // ���� �ϴµ� ����� ź���� ���ٸ� ( ex-> 30�� �����ؾ� �ϴµ� ������ 20�� ���� �� )
                {
                    currentBulletCount = carryBulletCount;
                    carryBulletCount = 0;
                }
            }
        }

        /*
        public IEnumerator ReloadCoroutine()
        {
            if (carryBulletCount > 0)
            {
                isReload = true;
                carryBulletCount += currentBulletCount;
                currentBulletCount = 0;

                yield return new WaitForSeconds(reloadTime);

                if (carryBulletCount >= reloadBulletCount) // �� �� ���� ������ ����� ź�� �����ϰ� �ִٸ�
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
        */

        public void CancelReload()
        {
            if (isReload == true)
            {
                StopAllCoroutines();
                isReload = false;
            }
        }


        public void PlaySE(AudioClip _clip)
        {
            audioSource.clip = _clip;
            audioSource.Play();
        }
    }
}
