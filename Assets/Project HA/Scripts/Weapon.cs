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
        public int reloadBulletCount; // 탄창 용량
        public int currentBulletCount; // 현재 탄창에 몇 발 남아있는지
        public int maxBulletCount; // 인벤토리에 저장 가능한 최대 탄환수
        public int carryBulletCount; // 현재 소유중인 탄환 개수

        public float retroActionForce; // 총기 반동세기
        public float retroActionFineSightForce; // 정조준 시 반동세기

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
                // 슈팅 가능
                lastShootTime = Time.time;
                gunController.PlaySE(fire_Sound);
                crosshair.FireAnimation();
                currentBulletCount--;

                // Muzzle 이펙트 만들기
                var newMuzzle = Instantiate(muzzlePrefab);
                newMuzzle.transform.SetPositionAndRotation(firePosition.position, firePosition.rotation * Quaternion.Euler(90,0,90));
                newMuzzle.gameObject.SetActive(true);
                Destroy(newMuzzle, 0.12f);

                // 총알 생성하기
                var newBullet = Instantiate(bulletPrefab);
                var cameraTransform = Camera.main.transform;
                newBullet.transform.SetPositionAndRotation(cameraTransform.position, cameraTransform.rotation);
                newBullet.gameObject.SetActive(true);

                // 탄피 생성

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

                if(carryBulletCount >= reloadBulletCount) // 한 번 장전 가능한 충분한 탄을 소유하고 있다면
                {
                    currentBulletCount = reloadBulletCount; // 정상 장전
                    carryBulletCount -= reloadBulletCount; // 장전한 탄 수만큼 소유분에서 차감
                }
                else // 장전 하는데 충분한 탄약이 없다면 ( ex-> 30발 장전해야 하는데 가진건 20발 뿐일 때 )
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
