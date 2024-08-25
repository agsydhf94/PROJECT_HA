using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HA
{
    public class Zombie : CharacterBase
    {
        public LayerMask targetLayerMask;

        private CharacterBase targetBase;
        private NavMeshAgent navMeshAgent;

        public ParticleSystem hitParticle;
        public AudioClip deathSound;
        public AudioClip hitSound;

        private Animator zombieAnimator;
        private AudioSource zombieAudioPlayer;
        private Renderer zombieRenderer;

        public float damage = 20f;
        public float attackTerm = 0.5f;
        private float lastAttackTime;

        private bool Target
        {
            get
            {
                if (targetBase != null && !targetBase.Dead)
                {
                    return true;
                }
                return false;
            }
        }

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            zombieAnimator = GetComponent<Animator>();
            zombieAudioPlayer = GetComponent<AudioSource>();
            zombieRenderer = GetComponentInChildren<Renderer>();
        }

        public void InitialSetup(ZombieData zombieData)
        {
            initialHealth = zombieData.health;
            currentHP = zombieData.health;

            damage = zombieData.health;

            navMeshAgent.speed = zombieData.speed;

            zombieRenderer.material.color = zombieData.skinColor;
        }

        private void Start()
        {
            StartCoroutine(UpdatePath());
        }

        private void Update()
        {
            zombieAnimator.SetBool("HasTarget", Target);
        }

        private IEnumerator UpdatePath()
        {
            while(!Dead)
            {
                if(Target)
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetBase.transform.position);
                }
                else
                {
                    navMeshAgent.isStopped = true;

                    Collider[] colliders = Physics.OverlapSphere(transform.position, 21f, targetLayerMask);
                    for(int i = 0; i < colliders.Length; i++)
                    {
                        CharacterBase characterBase = colliders[i].GetComponent<CharacterBase>();

                        if(characterBase != null && !characterBase.Dead)
                        {
                            targetBase = characterBase;
                            break;
                        }
                    }
                }
                yield return new WaitForSeconds(0.25f);
            }
        }

        public override void Damage(float damage, Vector3 hitPoint, Vector3 hitNormal)
        {
            if(!Dead)
            {
                hitParticle.transform.position = hitPoint;
                hitParticle.transform.rotation = Quaternion.LookRotation(hitNormal);
                hitParticle.Play();

                zombieAudioPlayer.PlayOneShot(hitSound);
            }

            base.Damage(damage, hitPoint, hitNormal);
        }

        public override void Die()
        {
            base.Die();

            Collider[] zombieColliders = GetComponents<Collider>();
            for(int i = 0; i < zombieColliders.Length; ++i)
            {
                zombieColliders[i].enabled = false;
            }

            navMeshAgent.isStopped = true;
            navMeshAgent.enabled = false;

            zombieAnimator.SetTrigger("Die");
            zombieAudioPlayer.PlayOneShot(deathSound);
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}
