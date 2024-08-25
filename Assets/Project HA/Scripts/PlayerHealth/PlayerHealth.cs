using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace HA
{
    public class PlayerHealth : CharacterBase
    {
        public AudioClip deathSoundClip;
        public AudioClip hitSoundClip;
        public AudioClip itemPickupClip;

        private AudioSource playerAudioPlayer;
        private Animator playerAnimator;

        private PlayerController playerController;

        private void Awake()
        {
            playerAnimator = GetComponentInChildren<Animator>();
            playerAudioPlayer = GetComponent<AudioSource>();
            playerController = GetComponent<PlayerController>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void IncreaseHP(float amount)
        {
            base.IncreaseHP(amount);
        }

        public override void Damage(float damage)
        {
            if(!Dead)
            {
                playerAudioPlayer.PlayOneShot(hitSoundClip);
            }

            base.Damage(damage);
        }

        public override void Die()
        {
            base.Die();

            playerAudioPlayer?.PlayOneShot(deathSoundClip);

            playerController.enabled = false;
        }
    }
}
