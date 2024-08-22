using HA;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace HA
{
    public class WeaponManager : MonoBehaviour
    {
        public float switchDelay = 1f;
        public GameObject[] weapon;
        public GameObject[] dummy_Weapon;

        private int index = 0;
        private bool isSwitching = false;
        public PlayerController playerController;

        // Update is called once per frame
        private void Update()
        {
            if(playerController.isArmed == true)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
                {
                    index++;
                    if (index >= weapon.Length)
                        index = 0;
                    StartCoroutine(SwitchDelay(index));
                }

                if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
                {
                    index--;
                    if (index < 0)
                        index = weapon.Length - 1;
                    StartCoroutine(SwitchDelay(index));
                }
            }
            
            
        }

        public void InitializeWeapon()
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                weapon[i].SetActive(false);
            }
            weapon[0].SetActive(true);
            index = 0;
        }

        private IEnumerator SwitchDelay(int newIndex)
        {
            isSwitching = true;
            SwitchWeapons(newIndex);
            yield return new WaitForSeconds(switchDelay);
            isSwitching = false;
        }

        private void SwitchWeapons(int newIndex)
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                weapon[i].SetActive(false);
            }
            weapon[newIndex].SetActive(true);
        }
        


    }
}
