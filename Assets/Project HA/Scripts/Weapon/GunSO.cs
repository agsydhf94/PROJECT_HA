using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

namespace HA
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Guns/Gun", order = 0)]
    public class GunSO : ScriptableObject
    {
        public GunType gunType;
        public string gunName;
        public GameObject modelPrefab;
        public Vector3 spawnPoint;
        public Vector3 spawnRotation;

        public ShootConfigurationSO shootConfig;
        public TrailConfigurationSO trailConfig;

        private MonoBehaviour activeMonoBehavior;
        private GameObject model;
        private float lastShootTime;
        private ParticleSystem shootSystem;
        private ObjectPool<TrailRenderer> trailPool;

        public void Spawn(Transform Parent, MonoBehaviour _activeMonoBehavior)
        {
            activeMonoBehavior = _activeMonoBehavior;
            lastShootTime = 0;  // 유니티 안에서 제대로 리셋되지 않을 때를 대비
            trailConfig = new ObjectPool<TrailRenderer>(CreateTrail);

            model = Instantiate(modelPrefab);
            model.transform.SetParent(Parent, false);
            model.transform.localPosition = spawnPoint;
            model.transform.localRotation = Quaternion.Euler(spawnRotation);

            shootSystem = model.GetComponentInChildren<ParticleSystem>();
        }

        public void Shoot()
        {
            if(Time.time > shootConfig.fireRate + lastShootTime)
            {
                lastShootTime = Time.time;    // 중요 부분
                shootSystem.Play();

                // Shooting Direction and Random Spreading
                Vector3 shootDirection = shootSystem.transform.forward
                    + new Vector3(Random.Range(-shootConfig.Spread.x, shootConfig.Spread.x),
                                  Random.Range(-shootConfig.Spread.y, shootConfig.Spread.y),
                                  Random.Range(-shootConfig.Spread.z, shootConfig.Spread.z));

                shootDirection.Normalize();
                        

                if(Physics.Raycast(
                    shootSystem.transform.position,
                    shootDirection,
                    out RaycastHit hit,
                    float.MaxValue,
                    shootConfig.HitMask
                    ))
                {
                    activeMonoBehavior.StartCoroutine(
                        PlayTrail(shootSystem.transform.position, hit.point, hit));                     
                }
                else
                {
                    activeMonoBehavior.StartCoroutine(
                        PlayTrail(shootSystem.transform.position, 
                                  shootSystem.transform.position + (shootDirection * trailConfig.missDistance)
                                  )
                        );
                }

            }
        }


        private IEnumerator PlayTrail(Vector3 startPoint, Vector3 endPoint, RaycastHit hit)
        {
            TrailRenderer instance = trailPool.Get();
            instance.gameObject.SetActive(true);
            instance.transform.position = startPoint;
            yield return null;

            instance.emitting = true;

            float distance = Vector3.Distance(startPoint, endPoint);
            float remainingDistance = distance;
            while(remainingDistance > 0)
            {
                instance.transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.Clamp01(1-(remainingDistance / distance)));
                remainingDistance -= trailConfig.simulationSpeed * Time.deltaTime;

                yield return null;
            }

            instance.transform.position = endPoint;

            if(hit.collider != null)
            {
                SurfaceManager
            }

            yield return new WaitForSeconds(trailConfig.duration);
            yield return null;
            instance.emitting = false;
            instance.gameObject.SetActive(false);
            trailPool.Release(instance);
        }


        private TrailRenderer CreateTrail()
        {
            GameObject instance = new GameObject("Bullet Trail");
            TrailRenderer trail = instance.AddComponent<TrailRenderer>();
            trail.colorGradient = trailConfig.color;
            trail.material = trailConfig.material;
            trail.widthCurve = trailConfig.widthCurve;
            trail.time = trailConfig.duration;
            trail.minVertexDistance = trailConfig.minVertexDistance;

            trail.emitting = false;
            trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            return trail;
        }

    }
}
