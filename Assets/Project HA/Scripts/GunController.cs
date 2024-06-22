using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class GunController : MonoBehaviour
    {
        [SerializeField]
        private Weapon currentGun;

        private AudioSource audioSource;



        private void PlaySE(AudioClip _clip)
        {
            audioSource.clip = _clip;
            audioSource.Play();
        }


    }
}