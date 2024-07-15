using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace HA
{
    public class CharacterBase : MonoBehaviour
    {
        public float currentHP;
        public float maxHP;

        public float currentMP;
        public float maxMP;

        public delegate void OnDamage(float currentHP, float maxHP);
        public OnDamage onDamageCallback;

        public delegate void OnCharacterDead();
        public OnCharacterDead onCharacterDead;

        public System.Action<float, float> OnDamaged;
        public System.Action<float, float> OnChangedHP;
        public System.Action<float, float> OnChangedMP;

        private Renderer[] characterRenderers;

        // public System.Action<float, float> onDamagedAction;

        // public event OnDamage onDamageCallbackEvent;

        private void Awake()
        {
            characterRenderers = GetComponentsInChildren<Renderer>();
        }

        public void Damage(float damage)
        {
            currentHP -= damage;

            //if (onDamageCallback != null)
            //{
            //    onDamageCallback(currentHP, maxHP);
            //}
            // onDamagedAction(currentHP, maxHP);

            OnDamaged?.Invoke(currentHP, maxHP);

            if (currentHP <= 0)
            {
                onCharacterDead();
                Destroy(gameObject);
            }
        }

        [ContextMenu("Damage Debug")]
        public void DamageDebugButton()
        {
            Damage(20);
        }

        public void IncreaseHP(float amount)
        {
            currentHP += amount;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);

            OnChangedHP?.Invoke(currentHP, maxHP);
        }
    }
}
