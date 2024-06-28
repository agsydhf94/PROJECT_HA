using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace HA
{
    public class IngameHUD : MonoBehaviour
    {
        
        public GunController gunController; 
        public Weapon currentWeapon;

        public GameObject bulletHUD;

        public Text[] text_Bullet; // Åº °³¼ö ¹Ý¿µ

        private void Awake()
        {
            gunController = GameObject.Find("WeaponHolder").GetComponent<GunController>();
        }

        private void Update()
        {
            CheckBullet();
        }

        private void CheckBullet()
        {
            currentWeapon = gunController.GetWeapon();
            text_Bullet[0].text = currentWeapon.carryBulletCount.ToString();
            text_Bullet[1].text = currentWeapon.currentBulletCount.ToString();
        }
    }
}
